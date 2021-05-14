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
    public class DeleteRequestDetailCommandHandler : RequestDetailCommandHandler, IRequestHandler<DeleteRequestDetailCommand, MethodResult<DeleteRequestDetailCommandResponse>>
    {
        public DeleteRequestDetailCommandHandler(IMapper mapper, IRequestDetailRepository RequestDetailRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, RequestDetailRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing RequestDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteRequestDetailCommandResponse>> Handle(DeleteRequestDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteRequestDetailCommandResponse>();
            var existingRequestDetails = await _RequestDetailRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingRequestDetails == null || !existingRequestDetails.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingRequestDetail in existingRequestDetails)
            {
                existingRequestDetail.UpdateDate = now;
                existingRequestDetail.UpdateDateUTC = utc;
                existingRequestDetail.IsDelete = true;
                existingRequestDetail.ModifyBy = 0;
                existingRequestDetail.SetUpdate(_user,0);
            }
            _RequestDetailRepository.UpdateRange(existingRequestDetails);
            await _RequestDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var RequestDetailResponseDTOs = _mapper.Map<List<RequestDetailCommandResponseDTO>>(existingRequestDetails);
            methodResult.Result = new DeleteRequestDetailCommandResponse(RequestDetailResponseDTOs);
            return methodResult;
        }
    }
}