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
    public class CreateNS_GoiThauCommandHandler : NS_GoiThauCommandHandler, IRequestHandler<CreateNS_GoiThauCommand, MethodResult<CreateNS_GoiThauCommandResponse>>
    {
        public CreateNS_GoiThauCommandHandler(IMapper mapper, INS_GoiThauRepository NS_GoiThauRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_GoiThauRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_GoiThau
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_GoiThauCommandResponse>> Handle(CreateNS_GoiThauCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_GoiThauCommandResponse>();
            var newNS_GoiThau = new NS_GoiThau(request.ParentId,
                request.ProjectId,
                request.SoHopDong,
                request.ContractorInfoId,
                request.NgayKy,
                request.DienGiai,
                request.ThoiGianBaoHanh,
                request.ThoiGianGiuBaoHanh,
                request.TyLeTamUng,
                request.TyLeGiuLai,
                request.TyLeThanhToanToiDa,
                request.GiaTri);
            newNS_GoiThau.SetCreate(_user);
            newNS_GoiThau.Status = request.Status.HasValue ? request.Status : newNS_GoiThau.Status;
            newNS_GoiThau.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_GoiThau.IsActive;
            newNS_GoiThau.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_GoiThau.IsVisible;
            await _NS_GoiThauRepository.AddAsync(newNS_GoiThau).ConfigureAwait(false);
            await _NS_GoiThauRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_GoiThauCommandResponse>(newNS_GoiThau);
            return methodResult;
        }
    }
}