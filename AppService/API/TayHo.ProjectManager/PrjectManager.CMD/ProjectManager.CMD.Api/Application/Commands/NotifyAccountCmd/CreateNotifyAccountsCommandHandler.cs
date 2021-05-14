using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNotifyAccountsCommandHandler : NotifyAccountCommandHandler, IRequestHandler<CreateNotifyAccountsCommand, MethodResult<CreateNotifyAccountCommandResponse>>
    {
        private readonly IGroupAccountRepository _groupAccount;
        public CreateNotifyAccountsCommandHandler(IMapper mapper, INotifyAccountRepository notifyAccountRepository, IHttpContextAccessor httpContextAccessor, IGroupAccountRepository groupAccount) : base(mapper, notifyAccountRepository, httpContextAccessor)
        {
            _groupAccount = groupAccount;
        }

        /// <summary>
        /// Handle for creating a new NotifyAccounts
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNotifyAccountCommandResponse>> Handle(CreateNotifyAccountsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNotifyAccountCommandResponse>();
            List<NotifyAccount> newNotifyAccounts = new List<NotifyAccount>();
            if (request.GroupId != null)
            {
                foreach (var group in request.GroupId)
                {
                    var existingGroupAccounts = await _groupAccount.GetAllListAsync(x => x.GroupId == group && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false);
                    if (existingGroupAccounts.Count > 0)
                    {
                        foreach (var groupAccount in existingGroupAccounts)
                        {
                            if (!await _notifyAccountRepository.AnyAsync(x => x.AccountId == groupAccount.AccountId && x.NotifyId == request.NotifyId && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false))
                            {
                                var newNotifyAccount = new NotifyAccount(groupAccount.AccountId,
                                                                            group,
                                                                            request.NotifyId,
                                                                            request.PushTime);
                                newNotifyAccount.SetCreate(_user);
                                newNotifyAccount.Status = request.Status.HasValue ? request.Status : 0;
                                newNotifyAccount.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                                newNotifyAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
                                newNotifyAccounts.Add(newNotifyAccount);
                            }
                        }
                    }
                }
            }
            else if (request.AccountId != null)
            {
                foreach (var account in request.AccountId)
                {
                    if (!await _notifyAccountRepository.AnyAsync(x => x.AccountId == account && x.NotifyId == request.NotifyId && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false))
                    {
                        var newNotifyAccount = new NotifyAccount(account,
                                                            0,
                                                            request.NotifyId,
                                                            request.PushTime);
                        newNotifyAccount.SetCreate(_user);
                        newNotifyAccount.Status = request.Status.HasValue ? request.Status : 0;
                        newNotifyAccount.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                        newNotifyAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
                        newNotifyAccounts.Add(newNotifyAccount);

                    }
                }
            }
            await _notifyAccountRepository.AddRangeAsync(newNotifyAccounts).ConfigureAwait(false);
            await _notifyAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NotifyAccountResponseDTOs = _mapper.Map<List<NotifyAccountCommandResponseDTO>>(newNotifyAccounts);
            methodResult.Result = new CreateNotifyAccountCommandResponse(NotifyAccountResponseDTOs);
            return methodResult;
        }
    }
}
