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
    public class DeleteNS_CongViecDetailCommandHandler : NS_CongViecDetailCommandHandler, IRequestHandler<DeleteNS_CongViecDetailCommand, MethodResult<DeleteNS_CongViecDetailCommandResponse>>
    {
        public DeleteNS_CongViecDetailCommandHandler(IMapper mapper, INS_CongViecDetailRepository NS_CongViecDetailRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_CongViecDetailRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_CongViecDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_CongViecDetailCommandResponse>> Handle(DeleteNS_CongViecDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_CongViecDetailCommandResponse>();
            var existingNS_CongViecDetail = await _NS_CongViecDetailRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_CongViecDetail == null || !existingNS_CongViecDetail.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_CongViecDetail)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_CongViecDetailRepository.UpdateRange(existingNS_CongViecDetail);
            await _NS_CongViecDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_CongViecDetailResponseDTOs = _mapper.Map<List<NS_CongViecDetailCommandResponseDTO>>(existingNS_CongViecDetail);
            methodResult.Result = new DeleteNS_CongViecDetailCommandResponse(NS_CongViecDetailResponseDTOs);
            return methodResult;
        }
    }
}