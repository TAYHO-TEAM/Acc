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
    public class CreateNS_NhomCongViecDetailCommandHandler : NS_NhomCongViecDetailCommandHandler, IRequestHandler<CreateNS_NhomCongViecDetailCommand, MethodResult<CreateNS_NhomCongViecDetailCommandResponse>>
    {
        public CreateNS_NhomCongViecDetailCommandHandler(IMapper mapper, INS_NhomCongViecDetailRepository NS_NhomCongViecDetailRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NhomCongViecDetailRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_NhomCongViecDetail
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_NhomCongViecDetailCommandResponse>> Handle(CreateNS_NhomCongViecDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_NhomCongViecDetailCommandResponse>();
            var newNS_NhomCongViecDetail = new NS_NhomCongViecDetail(request.NhomCongViecId,
request.GiaiDoanId,
request.GiaTri,
request.SortIndex);
            newNS_NhomCongViecDetail.SetCreate(_user);
            newNS_NhomCongViecDetail.Status = request.Status.HasValue ? request.Status : newNS_NhomCongViecDetail.Status;
            newNS_NhomCongViecDetail.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_NhomCongViecDetail.IsActive;
            newNS_NhomCongViecDetail.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_NhomCongViecDetail.IsVisible;
            await _NS_NhomCongViecDetailRepository.AddAsync(newNS_NhomCongViecDetail).ConfigureAwait(false);
            await _NS_NhomCongViecDetailRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_NhomCongViecDetailCommandResponse>(newNS_NhomCongViecDetail);
            return methodResult;
        }
    }
}