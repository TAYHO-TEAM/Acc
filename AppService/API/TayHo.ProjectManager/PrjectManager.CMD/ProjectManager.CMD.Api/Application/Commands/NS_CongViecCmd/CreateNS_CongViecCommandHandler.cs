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
    public class CreateNS_CongViecCommandHandler : NS_CongViecCommandHandler, IRequestHandler<CreateNS_CongViecCommand, MethodResult<CreateNS_CongViecCommandResponse>>
    {
        public CreateNS_CongViecCommandHandler(IMapper mapper, INS_CongViecRepository NS_CongViecRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_CongViecRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_CongViec
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_CongViecCommandResponse>> Handle(CreateNS_CongViecCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_CongViecCommandResponse>();
            var newNS_CongViec = new NS_CongViec(request.NhomCongViecId, 
                request.Nhom,
                request.TenCongViec,
                request.DienGiai,
                request.DonViTinh,
                request.SortIndex);
            newNS_CongViec.SetCreate(_user);
            newNS_CongViec.Status = request.Status.HasValue ? request.Status : newNS_CongViec.Status;
            newNS_CongViec.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_CongViec.IsActive;
            newNS_CongViec.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_CongViec.IsVisible;
            await _NS_CongViecRepository.AddAsync(newNS_CongViec).ConfigureAwait(false);
            await _NS_CongViecRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_CongViecCommandResponse>(newNS_CongViec);
            return methodResult;
        }
    }
}