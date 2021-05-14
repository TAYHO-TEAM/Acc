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
    public class DeleteNS_NhomCongViecDetailCommandHandler : NS_NhomCongViecDetailCommandHandler, IRequestHandler<DeleteNS_NhomCongViecDetailCommand, MethodResult<DeleteNS_NhomCongViecDetailCommandResponse>>
    {
        public DeleteNS_NhomCongViecDetailCommandHandler(IMapper mapper, INS_NhomCongViecDetailRepository NS_NhomCongViecDetailRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NhomCongViecDetailRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_NhomCongViecDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_NhomCongViecDetailCommandResponse>> Handle(DeleteNS_NhomCongViecDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_NhomCongViecDetailCommandResponse>();
            var existingNS_NhomCongViecDetail = await _NS_NhomCongViecDetailRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_NhomCongViecDetail == null || !existingNS_NhomCongViecDetail.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_NhomCongViecDetail)
            {
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_NhomCongViecDetailRepository.UpdateRange(existingNS_NhomCongViecDetail);
            await _NS_NhomCongViecDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_NhomCongViecDetailResponseDTOs = _mapper.Map<List<NS_NhomCongViecDetailCommandResponseDTO>>(existingNS_NhomCongViecDetail);
            methodResult.Result = new DeleteNS_NhomCongViecDetailCommandResponse(NS_NhomCongViecDetailResponseDTOs);
            return methodResult;
        }
    }
}