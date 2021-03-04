using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupAccountListCommandHandler : GroupAccountCommandHandler, IRequestHandler<CreateGroupAccountsCommand, MethodResult<CreateGroupAccountsCommandResponse>>
    {
        public CreateGroupAccountListCommandHandler(IMapper mapper, IGroupAccountRepository GroupAccountRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupAccountRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new GroupAccounts
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateGroupAccountsCommandResponse>> Handle(CreateGroupAccountsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateGroupAccountsCommandResponse>();
            List<GroupAccount> newGroupAccounts = new List<GroupAccount>();
            foreach (var item in request._GroupAccountCommands)
            {
                var newGroupAccount = new GroupAccount(item.AccountId,
                                                    item.GroupId);
                if (!(await _GroupAccountRepository.AnyAsync(x => x.AccountId == item.AccountId && x.GroupId == item.GroupId && x.IsDelete == false).ConfigureAwait(false)))
                {
                    newGroupAccount.SetCreate(_user);
                    newGroupAccount.Status = item.Status.HasValue ? item.Status : newGroupAccount.Status;
                    newGroupAccount.IsActive = item.IsActive.HasValue ? item.IsActive : true;
                    newGroupAccount.IsVisible = item.IsVisible.HasValue ? item.IsVisible : true;
                    newGroupAccounts.Add(newGroupAccount);
                }
            }
            await _GroupAccountRepository.AddRangeAsync(newGroupAccounts).ConfigureAwait(false);
            await _GroupAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var GroupAccountResponseDTOs = _mapper.Map<List<GroupAccountCommandResponseDTO>>(newGroupAccounts);
            methodResult.Result = new CreateGroupAccountsCommandResponse(GroupAccountResponseDTOs);
            return methodResult;
        }
    }
}