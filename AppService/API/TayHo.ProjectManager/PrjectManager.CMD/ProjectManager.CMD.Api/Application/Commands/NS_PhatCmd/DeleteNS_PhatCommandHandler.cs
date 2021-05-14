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
    public class DeleteNS_PhatCommandHandler : NS_PhatCommandHandler, IRequestHandler<DeleteNS_PhatCommand, MethodResult<DeleteNS_PhatCommandResponse>>
    {
        public DeleteNS_PhatCommandHandler(IMapper mapper, INS_PhatRepository NS_PhatRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_PhatRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_Phat.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_PhatCommandResponse>> Handle(DeleteNS_PhatCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_PhatCommandResponse>();
            var existingNS_Phat = await _NS_PhatRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_Phat == null || !existingNS_Phat.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_Phat)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_PhatRepository.UpdateRange(existingNS_Phat);
            await _NS_PhatRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_PhatResponseDTOs = _mapper.Map<List<NS_PhatCommandResponseDTO>>(existingNS_Phat);
            methodResult.Result = new DeleteNS_PhatCommandResponse(NS_PhatResponseDTOs);
            return methodResult;
        }
    }
}