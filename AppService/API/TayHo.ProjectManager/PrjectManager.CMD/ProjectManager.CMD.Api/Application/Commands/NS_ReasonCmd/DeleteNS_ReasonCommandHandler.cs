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
    public class DeleteNS_ReasonCommandHandler : NS_ReasonCommandHandler, IRequestHandler<DeleteNS_ReasonCommand, MethodResult<DeleteNS_ReasonCommandResponse>>
    {
        public DeleteNS_ReasonCommandHandler(IMapper mapper, INS_ReasonRepository NS_ReasonRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_ReasonRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_Reason.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_ReasonCommandResponse>> Handle(DeleteNS_ReasonCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_ReasonCommandResponse>();
            var existingNS_Reason = await _NS_ReasonRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_Reason == null || !existingNS_Reason.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_Reason)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_ReasonRepository.UpdateRange(existingNS_Reason);
            await _NS_ReasonRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_ReasonResponseDTOs = _mapper.Map<List<NS_ReasonCommandResponseDTO>>(existingNS_Reason);
            methodResult.Result = new DeleteNS_ReasonCommandResponse(NS_ReasonResponseDTOs);
            return methodResult;
        }
    }
}