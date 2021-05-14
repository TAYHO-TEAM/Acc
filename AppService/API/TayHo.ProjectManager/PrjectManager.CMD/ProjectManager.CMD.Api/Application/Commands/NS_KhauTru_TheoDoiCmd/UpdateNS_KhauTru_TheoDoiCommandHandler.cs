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
    public class UpdateNS_KhauTru_TheoDoiCommandHandler : NS_KhauTru_TheoDoiCommandHandler,IRequestHandler<UpdateNS_KhauTru_TheoDoiCommand, MethodResult<UpdateNS_KhauTru_TheoDoiCommandResponse>>
    {
        public UpdateNS_KhauTru_TheoDoiCommandHandler(IMapper mapper, INS_KhauTru_TheoDoiRepository NS_KhauTru_TheoDoiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_KhauTru_TheoDoiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_KhauTru_TheoDoi.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_KhauTru_TheoDoiCommandResponse>> Handle(UpdateNS_KhauTru_TheoDoiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_KhauTru_TheoDoiCommandResponse>();
            var existingNS_KhauTru_TheoDoi = await _NS_KhauTru_TheoDoiRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_KhauTru_TheoDoi == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_KhauTru_TheoDoi.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_KhauTru_TheoDoi.IsActive;
            existingNS_KhauTru_TheoDoi.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_KhauTru_TheoDoi.IsVisible;
            existingNS_KhauTru_TheoDoi.Status = request.Status.HasValue ? request.Status : existingNS_KhauTru_TheoDoi.Status;
            existingNS_KhauTru_TheoDoi.SetKhauTruId(request.KhauTruId);
            existingNS_KhauTru_TheoDoi.SetNoiDung(request.NoiDung);
            existingNS_KhauTru_TheoDoi.SetDienGiai(request.DienGiai);
            existingNS_KhauTru_TheoDoi.SetGiaTri(request.GiaTri);
            existingNS_KhauTru_TheoDoi.SetDot(request.Dot);
            existingNS_KhauTru_TheoDoi.SetUpdate(_user,0);
            _NS_KhauTru_TheoDoiRepository.Update(existingNS_KhauTru_TheoDoi);
            await _NS_KhauTru_TheoDoiRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_KhauTru_TheoDoiCommandResponse>(existingNS_KhauTru_TheoDoi);
            return methodResult;
        }
    }
}