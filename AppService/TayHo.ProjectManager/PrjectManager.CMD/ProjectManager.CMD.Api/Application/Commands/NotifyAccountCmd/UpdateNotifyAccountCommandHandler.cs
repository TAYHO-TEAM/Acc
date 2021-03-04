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

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNotifyAccountCommandHandler : NotifyAccountCommandHandler,IRequestHandler<UpdateNotifyAccountCommand, MethodResult<UpdateNotifyAccountCommandResponse>>
    {
        public UpdateNotifyAccountCommandHandler(IMapper mapper, INotifyAccountRepository notifyAccountRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, notifyAccountRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NotifyAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNotifyAccountCommandResponse>> Handle(UpdateNotifyAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNotifyAccountCommandResponse>();
            var existingNotifyAccount = await _notifyAccountRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNotifyAccount == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNotifyAccount.IsActive = request.IsActive.HasValue ? request.IsActive : existingNotifyAccount.IsActive;
            existingNotifyAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNotifyAccount.IsVisible;
            existingNotifyAccount.Status = request.Status.HasValue ? request.Status : existingNotifyAccount.Status;

            existingNotifyAccount.SetAccountId(request.AccountId);
	existingNotifyAccount.SetGroupId(request.GroupId);
			existingNotifyAccount.SetNotifyId(request.NotifyId);
			existingNotifyAccount.SetPushTime(request.PushTime);
			

            existingNotifyAccount.SetUpdate(_user,null);
            _notifyAccountRepository.Update(existingNotifyAccount);
            await _notifyAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNotifyAccountCommandResponse>(existingNotifyAccount);
            return methodResult;
        }
    }
}
