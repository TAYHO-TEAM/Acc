using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_CongViecDetailCommandHandler : NS_CongViecDetailCommandHandler, IRequestHandler<CreateNS_CongViecDetailCommand, MethodResult<CreateNS_CongViecDetailCommandResponse>>
    {
        public CreateNS_CongViecDetailCommandHandler(IMapper mapper, INS_CongViecDetailRepository NS_CongViecDetailRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_CongViecDetailRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_CongViecDetail
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_CongViecDetailCommandResponse>> Handle(CreateNS_CongViecDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_CongViecDetailCommandResponse>();
            var newNS_CongViecDetail = new NS_CongViecDetail(
                request.CongViecId,
                request.ReasonId,
                request.GiaiDoanId,
                request.DonGia,
                request.KhoiLuong);
            newNS_CongViecDetail.SetCreate(_user);
            newNS_CongViecDetail.Status = request.Status.HasValue ? request.Status : newNS_CongViecDetail.Status;
            newNS_CongViecDetail.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_CongViecDetail.IsActive;
            newNS_CongViecDetail.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_CongViecDetail.IsVisible;
            await _NS_CongViecDetailRepository.AddAsync(newNS_CongViecDetail).ConfigureAwait(false);
            await _NS_CongViecDetailRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_CongViecDetailCommandResponse>(newNS_CongViecDetail);
            return methodResult;
        }
    }
}