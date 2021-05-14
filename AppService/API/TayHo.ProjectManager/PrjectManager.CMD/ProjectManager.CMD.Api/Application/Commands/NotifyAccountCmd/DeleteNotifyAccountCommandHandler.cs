using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNotifyAccountCommandHandler : NotifyAccountCommandHandler, IRequestHandler<DeleteNotifyAccountCommand, MethodResult<DeleteNotifyAccountCommandResponse>>
    {
        public DeleteNotifyAccountCommandHandler(IMapper mapper, INotifyAccountRepository notifyAccountRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, notifyAccountRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NotifyAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNotifyAccountCommandResponse>> Handle(DeleteNotifyAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNotifyAccountCommandResponse>();
            var existingNotifyAccounts = await _notifyAccountRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNotifyAccounts == null || !existingNotifyAccounts.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingNotifyAccount in existingNotifyAccounts)
            {
                existingNotifyAccount.UpdateDate = now;
                existingNotifyAccount.UpdateDateUTC = utc;
                existingNotifyAccount.IsDelete = true;
                existingNotifyAccount.SetUpdate(_user, null);
            }
            _notifyAccountRepository.UpdateRange(existingNotifyAccounts);
            await _notifyAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NotifyAccountResponseDTOs = _mapper.Map<List<NotifyAccountCommandResponseDTO>>(existingNotifyAccounts);
            methodResult.Result = new DeleteNotifyAccountCommandResponse(NotifyAccountResponseDTOs);
            return methodResult;
        }
    }
}
