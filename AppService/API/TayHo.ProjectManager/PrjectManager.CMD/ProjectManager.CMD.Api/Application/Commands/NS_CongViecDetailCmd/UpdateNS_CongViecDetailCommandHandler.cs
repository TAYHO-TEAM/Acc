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
    public class UpdateNS_CongViecDetailCommandHandler : NS_CongViecDetailCommandHandler,IRequestHandler<UpdateNS_CongViecDetailCommand, MethodResult<UpdateNS_CongViecDetailCommandResponse>>
    {
        public UpdateNS_CongViecDetailCommandHandler(IMapper mapper, INS_CongViecDetailRepository NS_CongViecDetailRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_CongViecDetailRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_CongViecDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_CongViecDetailCommandResponse>> Handle(UpdateNS_CongViecDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_CongViecDetailCommandResponse>();
            var existingNS_CongViecDetail = await _NS_CongViecDetailRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_CongViecDetail == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_CongViecDetail.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_CongViecDetail.IsActive;
            existingNS_CongViecDetail.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_CongViecDetail.IsVisible;
            existingNS_CongViecDetail.Status = request.Status.HasValue ? request.Status : existingNS_CongViecDetail.Status;
            existingNS_CongViecDetail.SetCongViecId(request.CongViecId);
            existingNS_CongViecDetail.SetReasonId(request.ReasonId);
            existingNS_CongViecDetail.SetGiaiDoanId(request.GiaiDoanId);
            existingNS_CongViecDetail.SetDonGia(request.DonGia);
            existingNS_CongViecDetail.SetKhoiLuong(request.KhoiLuong);
            existingNS_CongViecDetail.SetUpdate(_user,0);
            _NS_CongViecDetailRepository.Update(existingNS_CongViecDetail);
            await _NS_CongViecDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_CongViecDetailCommandResponse>(existingNS_CongViecDetail);
            return methodResult;
        }
    }
}