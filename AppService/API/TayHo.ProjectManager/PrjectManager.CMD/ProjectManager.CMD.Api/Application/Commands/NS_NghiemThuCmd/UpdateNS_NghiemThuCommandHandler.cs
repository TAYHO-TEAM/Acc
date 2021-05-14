using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_NghiemThuCommandHandler : NS_NghiemThuCommandHandler, IRequestHandler<UpdateNS_NghiemThuCommand, MethodResult<UpdateNS_NghiemThuCommandResponse>>
    {
        public UpdateNS_NghiemThuCommandHandler(IMapper mapper, INS_NghiemThuRepository Repository, IHttpContextAccessor httpContextAccessor) : base(mapper, Repository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_NghiemThu.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_NghiemThuCommandResponse>> Handle(UpdateNS_NghiemThuCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_NghiemThuCommandResponse>();
            var existingNS_NghiemThu = await _nS_NghiemThuRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_NghiemThu == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_NghiemThu.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_NghiemThu.IsActive;
            existingNS_NghiemThu.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_NghiemThu.IsVisible;
            existingNS_NghiemThu.Status = request.Status.HasValue ? request.Status : existingNS_NghiemThu.Status;

            existingNS_NghiemThu.SetCongViecDetailId(request.CongViecDetailId);
            existingNS_NghiemThu.SetGoiThauId(request.GoiThauId);
            existingNS_NghiemThu.SetGiaiDoanId(request.GiaiDoanId);
            existingNS_NghiemThu.SetDot(request.Dot);
            existingNS_NghiemThu.SetKhoiLuong(request.KhoiLuong);

            existingNS_NghiemThu.SetUpdate(_user, null);
            _nS_NghiemThuRepository.Update(existingNS_NghiemThu);
            await _nS_NghiemThuRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_NghiemThuCommandResponse>(existingNS_NghiemThu);
            return methodResult;
        }
    }
}
