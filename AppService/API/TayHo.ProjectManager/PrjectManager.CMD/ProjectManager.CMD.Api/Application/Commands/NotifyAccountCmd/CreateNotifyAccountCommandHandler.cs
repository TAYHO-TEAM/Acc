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
    public class CreateNotifyAccountCommandHandler : NotifyAccountCommandHandler, IRequestHandler<CreateNotifyAccountCommand, MethodResult<CreateNotifyAccountCommandResponse>>
    {
        private readonly IGroupAccountRepository _groupAccount;
        public CreateNotifyAccountCommandHandler(IMapper mapper, INotifyAccountRepository notifyAccountRepository, IHttpContextAccessor httpContextAccessor, IGroupAccountRepository groupAccount) : base(mapper, notifyAccountRepository, httpContextAccessor)
        {
            _groupAccount = groupAccount;
        }

        /// <summary>
        /// Handle for creating a new NotifyAccount
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNotifyAccountCommandResponse>> Handle(CreateNotifyAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNotifyAccountCommandResponse>();
            List<NotifyAccount> newNotifyAccounts = new List<NotifyAccount>();
            var existingGroupAccounts = await _groupAccount.GetAllListAsync(x => x.GroupId == (request.GroupId.HasValue? request.GroupId :0) && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false);
            if (request.GroupId.HasValue && existingGroupAccounts.Count > 0)
            {
                foreach (var groupAccount in existingGroupAccounts)
                {
                    if (!await _notifyAccountRepository.AnyAsync(x => x.AccountId == groupAccount.AccountId && x.NotifyId == request.NotifyId && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false))
                    {
                        var newNotifyAccount = new NotifyAccount(groupAccount.AccountId,
                                                                    request.GroupId,
                                                                    request.NotifyId,
                                                                    request.PushTime);
                        newNotifyAccount.SetCreate(_user);
                        newNotifyAccount.Status = request.Status.HasValue ? request.Status : 0;
                        newNotifyAccount.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                        newNotifyAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
                        newNotifyAccounts.Add(newNotifyAccount);
                    }
                }
                await _notifyAccountRepository.AddRangeAsync(newNotifyAccounts).ConfigureAwait(false);
                await _notifyAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            else if (request.AccountId > 0)
            {
                if (!await _notifyAccountRepository.AnyAsync(x => x.AccountId == request.AccountId && x.NotifyId == request.NotifyId && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false))
                {
                    var newNotifyAccount = new NotifyAccount(request.AccountId,
                                                        request.GroupId,
                                                        request.NotifyId,
                                                        request.PushTime);
                    newNotifyAccount.SetCreate(_user);
                    newNotifyAccount.Status = request.Status.HasValue ? request.Status : 0;
                    newNotifyAccount.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                    newNotifyAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
                    newNotifyAccounts.Add(newNotifyAccount);
                    await _notifyAccountRepository.AddAsync(newNotifyAccount).ConfigureAwait(false);
                    await _notifyAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
               
            }
           

            var NotifyAccountResponseDTOs = _mapper.Map<List<NotifyAccountCommandResponseDTO>>(newNotifyAccounts);
            methodResult.Result = new CreateNotifyAccountCommandResponse(NotifyAccountResponseDTOs);
            return methodResult;
        }
    }
}
