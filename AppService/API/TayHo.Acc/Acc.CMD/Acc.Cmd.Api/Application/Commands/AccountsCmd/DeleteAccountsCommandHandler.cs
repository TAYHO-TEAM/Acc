using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteAccountsCommandHandler : AccountsCommandHandler, IRequestHandler<DeleteAccountsCommand, MethodResult<DeleteAccountsCommandResponse>>
    {
        public DeleteAccountsCommandHandler(IMapper mapper, IAccountsRepository AccountsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, AccountsRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Accounts.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteAccountsCommandResponse>> Handle(DeleteAccountsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteAccountsCommandResponse>();
            var existingAccountss = await _accountsRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingAccountss == null || !existingAccountss.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAccounts in existingAccountss)
            {
                existingAccounts.UpdateDate = now;
                existingAccounts.UpdateDateUTC = utc;
                existingAccounts.IsDelete = true;
                existingAccounts.SetUpdate(_user, null);

            }
            _accountsRepository.UpdateRange(existingAccountss);
            await _accountsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var AccountsResponseDTOs = _mapper.Map<List<AccountsCommandResponseDTO>>(existingAccountss);
            methodResult.Result = new DeleteAccountsCommandResponse(AccountsResponseDTOs);
            return methodResult;
        }
    }
}