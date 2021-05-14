using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteAssignmentsCommandHandler : AssignmentsCommandHandler, IRequestHandler<DeleteAssignmentsCommand, MethodResult<DeleteAssignmentsCommandResponse>>
    {
        public DeleteAssignmentsCommandHandler(IMapper mapper, IAssignmentsRepository AssignmentsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, AssignmentsRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Assignments.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteAssignmentsCommandResponse>> Handle(DeleteAssignmentsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteAssignmentsCommandResponse>();
            var existingAssignments = await _AssignmentsRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingAssignments == null || !existingAssignments.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingAssignments)
            {
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _AssignmentsRepository.UpdateRange(existingAssignments);
            await _AssignmentsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var AssignmentsResponseDTOs = _mapper.Map<List<AssignmentsCommandResponseDTO>>(existingAssignments);
            methodResult.Result = new DeleteAssignmentsCommandResponse(AssignmentsResponseDTOs);
            return methodResult;
        }
    }
}