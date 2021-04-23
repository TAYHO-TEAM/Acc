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
    public class CreateNS_NhomCongViecCommandHandler : NS_NhomCongViecCommandHandler, IRequestHandler<CreateNS_NhomCongViecCommand, MethodResult<CreateNS_NhomCongViecCommandResponse>>
    {
        public CreateNS_NhomCongViecCommandHandler(IMapper mapper, INS_NhomCongViecRepository NS_NhomCongViecRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NhomCongViecRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_NhomCongViec
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_NhomCongViecCommandResponse>> Handle(CreateNS_NhomCongViecCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_NhomCongViecCommandResponse>();
            var newNS_NhomCongViec = new NS_NhomCongViec(
                request.HangMucId,
                request.LoaiCongViecId,
                request.GoiThauId,
                request.NhomChiPhiId,
                request.ProjectId,
                request.TenNhomCongViec,
                request.DienGiai,
                request.SortIndex);
            newNS_NhomCongViec.SetCreate(_user);
            newNS_NhomCongViec.Status = request.Status.HasValue ? request.Status : newNS_NhomCongViec.Status;
            newNS_NhomCongViec.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_NhomCongViec.IsActive;
            newNS_NhomCongViec.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_NhomCongViec.IsVisible;
            await _NS_NhomCongViecRepository.AddAsync(newNS_NhomCongViec).ConfigureAwait(false);
            await _NS_NhomCongViecRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_NhomCongViecCommandResponse>(newNS_NhomCongViec);
            return methodResult;
        }
    }
}