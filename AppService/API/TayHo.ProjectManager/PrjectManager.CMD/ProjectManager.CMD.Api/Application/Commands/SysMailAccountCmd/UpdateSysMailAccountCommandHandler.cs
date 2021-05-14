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
    public class UpdateSysMailAccountCommandHandler : SysMailAccountCommandHandler, IRequestHandler<UpdateSysMailAccountCommand, MethodResult<UpdateSysMailAccountCommandResponse>>
    {
        public UpdateSysMailAccountCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysMailAccountRepository sysMailAccountRepository) : base(mapper, httpContextAccessor, sysMailAccountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing SysMailAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateSysMailAccountCommandResponse>> Handle(UpdateSysMailAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateSysMailAccountCommandResponse>();
            var existingSysMailAccount = await _sysMailAccountRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingSysMailAccount == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingSysMailAccount.IsActive = request.IsActive.HasValue ? request.IsActive : existingSysMailAccount.IsActive;
            existingSysMailAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingSysMailAccount.IsVisible;
            existingSysMailAccount.Status = request.Status.HasValue ? request.Status : existingSysMailAccount.Status;

            existingSysMailAccount.SetSysAutoSendMailId(request.SysAutoSendMailId);
            existingSysMailAccount.SetEmail(request.Email);
            existingSysMailAccount.SetType(request.Type);


            existingSysMailAccount.SetUpdate(_user, null);
            _sysMailAccountRepository.Update(existingSysMailAccount);
            await _sysMailAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateSysMailAccountCommandResponse>(existingSysMailAccount);
            return methodResult;
        }
    }
}
