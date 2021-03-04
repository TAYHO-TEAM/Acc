using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_NghiemThuCommandHandler : NS_NghiemThuCommandHandler, IRequestHandler<CreateNS_NghiemThuCommand, MethodResult<CreateNS_NghiemThuCommandResponse>>
    {
        public CreateNS_NghiemThuCommandHandler(IMapper mapper, INS_NghiemThuRepository Repository,IHttpContextAccessor httpContextAccessor) : base(mapper, Repository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_NghiemThu
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_NghiemThuCommandResponse>> Handle(CreateNS_NghiemThuCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_NghiemThuCommandResponse>();
            var newNS_NghiemThu = new NS_NghiemThu(request.CongViecDetailId,
request.GoiThauId,
request.GiaiDoanId,
request.Dot,
request.KhoiLuong);
            newNS_NghiemThu.SetCreate(_user);
            newNS_NghiemThu.Status = request.Status.HasValue ? request.Status : newNS_NghiemThu.Status;
            newNS_NghiemThu.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_NghiemThu.IsActive;
            newNS_NghiemThu.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newNS_NghiemThu.IsVisible;
            await _nS_NghiemThuRepository.AddAsync(newNS_NghiemThu).ConfigureAwait(false);
            await _nS_NghiemThuRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_NghiemThuCommandResponse>(newNS_NghiemThu);
            return methodResult;
        }
    }
}
