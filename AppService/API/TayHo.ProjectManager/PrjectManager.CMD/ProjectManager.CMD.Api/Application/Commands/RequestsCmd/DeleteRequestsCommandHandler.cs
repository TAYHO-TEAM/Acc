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
    public class DeleteRequestsCommandHandler : RequestsCommandHandler, IRequestHandler<DeleteRequestsCommand, MethodResult<DeleteRequestsCommandResponse>>
    {
        public DeleteRequestsCommandHandler(IMapper mapper, IRequestsRepository RequestsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, RequestsRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Requests.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteRequestsCommandResponse>> Handle(DeleteRequestsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteRequestsCommandResponse>();
            var existingRequests = await _RequestsRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingRequests == null || !existingRequests.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingRequest in existingRequests)
            {
                existingRequest.UpdateDate = now;
                existingRequest.UpdateDateUTC = utc;
                existingRequest.IsDelete = true;
                existingRequest.ModifyBy = 0;
                existingRequest.SetUpdate(_user,0);
            }
            _RequestsRepository.UpdateRange(existingRequests);
            await _RequestsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var RequestsResponseDTOs = _mapper.Map<List<RequestsCommandResponseDTO>>(existingRequests);
            methodResult.Result = new DeleteRequestsCommandResponse(RequestsResponseDTOs);
            return methodResult;
        }
    }
}