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
    public class UpdateNS_Phat_TheoDoiCommandHandler : NS_Phat_TheoDoiCommandHandler,IRequestHandler<UpdateNS_Phat_TheoDoiCommand, MethodResult<UpdateNS_Phat_TheoDoiCommandResponse>>
    {
        public UpdateNS_Phat_TheoDoiCommandHandler(IMapper mapper, INS_Phat_TheoDoiRepository NS_Phat_TheoDoiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_Phat_TheoDoiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_Phat_TheoDoi.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_Phat_TheoDoiCommandResponse>> Handle(UpdateNS_Phat_TheoDoiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_Phat_TheoDoiCommandResponse>();
            var existingNS_Phat_TheoDoi = await _NS_Phat_TheoDoiRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_Phat_TheoDoi == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_Phat_TheoDoi.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_Phat_TheoDoi.IsActive;
            existingNS_Phat_TheoDoi.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_Phat_TheoDoi.IsVisible;
            existingNS_Phat_TheoDoi.Status = request.Status.HasValue ? request.Status : existingNS_Phat_TheoDoi.Status;
            existingNS_Phat_TheoDoi.SetPhatId(request.PhatId);
            existingNS_Phat_TheoDoi.SetNoiDung(request.NoiDung);
            existingNS_Phat_TheoDoi.SetDienGiai(request.DienGiai);
            existingNS_Phat_TheoDoi.SetGiaTri(request.GiaTri);
            existingNS_Phat_TheoDoi.SetDot(request.Dot);
            existingNS_Phat_TheoDoi.SetUpdate(_user,0);
            _NS_Phat_TheoDoiRepository.Update(existingNS_Phat_TheoDoi);
            await _NS_Phat_TheoDoiRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_Phat_TheoDoiCommandResponse>(existingNS_Phat_TheoDoi);
            return methodResult;
        }
    }
}