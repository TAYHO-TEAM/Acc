using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateAccountsCommandHandler : AccountsCommandHandler,IRequestHandler<UpdateAccountsCommand, MethodResult<UpdateAccountsCommandResponse>>
    {
        public UpdateAccountsCommandHandler(IMapper mapper, IAccountsRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing Accounts.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateAccountsCommandResponse>> Handle(UpdateAccountsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateAccountsCommandResponse>();
            var existingAccounts = await _accountsRepository.SingleOrDefaultAsync(x => x.Id == request.Id && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false);
            //if (existingAccounts.CreateBy != _user)
            //{
            //    methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr02), new[]
            //    {
            //        ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
            //    });
            //}
            if (existingAccounts == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GetCommonErrorMessage(nameof(ErrorCodeUpdate.UErr01))
                }); ;
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingAccounts.IsActive = request.IsActive.HasValue ? request.IsActive : existingAccounts.IsActive;
            existingAccounts.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingAccounts.IsVisible;
            existingAccounts.Status = request.Status.HasValue ? request.Status : existingAccounts.Status;
            existingAccounts.SetCode(request.Code);
            existingAccounts.SetType(request.Type);
            //existingAccounts.SetAccountName(request.AccountName);
            existingAccounts.SetPasswordHash(request.Password);
            existingAccounts.SetUserId(request.UserId);
            existingAccounts.SetUpdate(_user,null);
            _accountsRepository.Update(existingAccounts);
            await _accountsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateAccountsCommandResponse>(existingAccounts);
            return methodResult;
        }
    }
}