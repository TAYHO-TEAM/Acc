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
    public class UpdateNS_GoiThauCommandHandler : NS_GoiThauCommandHandler,IRequestHandler<UpdateNS_GoiThauCommand, MethodResult<UpdateNS_GoiThauCommandResponse>>
    {
        public UpdateNS_GoiThauCommandHandler(IMapper mapper, INS_GoiThauRepository NS_GoiThauRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_GoiThauRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_GoiThau.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_GoiThauCommandResponse>> Handle(UpdateNS_GoiThauCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_GoiThauCommandResponse>();
            var existingNS_GoiThau = await _NS_GoiThauRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_GoiThau == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_GoiThau.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_GoiThau.IsActive;
            existingNS_GoiThau.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_GoiThau.IsVisible;
            existingNS_GoiThau.Status = request.Status.HasValue ? request.Status : existingNS_GoiThau.Status;
            existingNS_GoiThau.SetParentId(request.ParentId);
            existingNS_GoiThau.SetProjectId(request.ProjectId);
            existingNS_GoiThau.SetSoHopDong(request.SoHopDong);
            existingNS_GoiThau.SetContractorInfoId(request.ContractorInfoId);
            existingNS_GoiThau.SetNgayKy(request.NgayKy);
            existingNS_GoiThau.SetDienGiai(request.DienGiai);
            existingNS_GoiThau.SetThoiGianBaoHanh(request.ThoiGianBaoHanh);
            existingNS_GoiThau.SetThoiGianGiuBaoHanh(request.ThoiGianGiuBaoHanh);
            existingNS_GoiThau.SetTyLeTamUng(request.TyLeTamUng);
            existingNS_GoiThau.SetTyLeGiuLai(request.TyLeGiuLai);
            existingNS_GoiThau.SetTyLeThanhToanToiDa(request.TyLeThanhToanToiDa);
            existingNS_GoiThau.SetGiaTri(request.GiaTri);
            existingNS_GoiThau.SetUpdate(_user,0);
            _NS_GoiThauRepository.Update(existingNS_GoiThau);
            await _NS_GoiThauRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_GoiThauCommandResponse>(existingNS_GoiThau);
            return methodResult;
        }
    }
}