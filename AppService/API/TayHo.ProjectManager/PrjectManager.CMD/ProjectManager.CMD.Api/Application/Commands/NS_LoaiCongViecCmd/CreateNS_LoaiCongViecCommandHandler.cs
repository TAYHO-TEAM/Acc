using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_LoaiCongViecCommandHandler : NS_LoaiCongViecCommandHandler, IRequestHandler<CreateNS_LoaiCongViecCommand, MethodResult<CreateNS_LoaiCongViecCommandResponse>>
    {
        public CreateNS_LoaiCongViecCommandHandler(IMapper mapper, INS_LoaiCongViecRepository NS_LoaiCongViecRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, NS_LoaiCongViecRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_LoaiCongViec
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_LoaiCongViecCommandResponse>> Handle(CreateNS_LoaiCongViecCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_LoaiCongViecCommandResponse>();
            var newNS_LoaiCongViec = new NS_LoaiCongViec(request.TenLoaiCongViec,
                request.DienGiai,
                request.KyHieu,
                request.ProjectId,
                request.SortIndex);
            newNS_LoaiCongViec.SetCreate(_user);
            newNS_LoaiCongViec.Status = request.Status.HasValue ? request.Status : newNS_LoaiCongViec.Status;
            newNS_LoaiCongViec.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_LoaiCongViec.IsActive;
            newNS_LoaiCongViec.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newNS_LoaiCongViec.IsVisible;
            await _NS_LoaiCongViecRepository.AddAsync(newNS_LoaiCongViec).ConfigureAwait(false);
            await _NS_LoaiCongViecRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_LoaiCongViecCommandResponse>(newNS_LoaiCongViec);
            return methodResult;
        }
    }
}