using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateAssignmentsCommandHandler : AssignmentsCommandHandler,IRequestHandler<UpdateAssignmentsCommand, MethodResult<UpdateAssignmentsCommandResponse>>
    {
        public UpdateAssignmentsCommandHandler(IMapper mapper, IAssignmentsRepository AssignmentsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, AssignmentsRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing Assignments.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateAssignmentsCommandResponse>> Handle(UpdateAssignmentsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateAssignmentsCommandResponse>();
            var existingAssignments = await _AssignmentsRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingAssignments == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingAssignments.IsActive = request.IsActive.HasValue ? request.IsActive : existingAssignments.IsActive;
            existingAssignments.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingAssignments.IsVisible;
            existingAssignments.Status = request.Status.HasValue ? request.Status : existingAssignments.Status;
            existingAssignments.SetRequestId(request.RequestId);
            existingAssignments.SetRequestDetailId(request.RequestDetailId);
            existingAssignments.SetUpdate(_user,0);
            _AssignmentsRepository.Update(existingAssignments);
            await _AssignmentsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateAssignmentsCommandResponse>(existingAssignments);
            return methodResult;
        }
    }
}