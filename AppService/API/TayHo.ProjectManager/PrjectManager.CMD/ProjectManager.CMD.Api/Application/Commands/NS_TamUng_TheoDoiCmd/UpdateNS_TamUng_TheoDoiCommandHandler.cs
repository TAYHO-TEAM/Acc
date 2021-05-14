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
    public class UpdateNS_TamUng_TheoDoiCommandHandler : NS_TamUng_TheoDoiCommandHandler,IRequestHandler<UpdateNS_TamUng_TheoDoiCommand, MethodResult<UpdateNS_TamUng_TheoDoiCommandResponse>>
    {
        public UpdateNS_TamUng_TheoDoiCommandHandler(IMapper mapper, INS_TamUng_TheoDoiRepository NS_TamUng_TheoDoiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_TamUng_TheoDoiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_TamUng_TheoDoi.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_TamUng_TheoDoiCommandResponse>> Handle(UpdateNS_TamUng_TheoDoiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_TamUng_TheoDoiCommandResponse>();
            var existingNS_TamUng_TheoDoi = await _NS_TamUng_TheoDoiRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_TamUng_TheoDoi == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_TamUng_TheoDoi.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_TamUng_TheoDoi.IsActive;
            existingNS_TamUng_TheoDoi.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_TamUng_TheoDoi.IsVisible;
            existingNS_TamUng_TheoDoi.Status = request.Status.HasValue ? request.Status : existingNS_TamUng_TheoDoi.Status;
            existingNS_TamUng_TheoDoi.SetTamUngId(request.TamUngId);
            existingNS_TamUng_TheoDoi.SetNoiDung(request.NoiDung);
            existingNS_TamUng_TheoDoi.SetDienGiai(request.DienGiai);
            existingNS_TamUng_TheoDoi.SetGiaTri(request.GiaTri);
            existingNS_TamUng_TheoDoi.SetDot(request.Dot);
            existingNS_TamUng_TheoDoi.SetUpdate(_user,0);
            _NS_TamUng_TheoDoiRepository.Update(existingNS_TamUng_TheoDoi);
            await _NS_TamUng_TheoDoiRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_TamUng_TheoDoiCommandResponse>(existingNS_TamUng_TheoDoi);
            return methodResult;
        }
    }
}