using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanAccountCommandHandler : PlanAccountCommandHandler, IRequestHandler<CreatePlanAccountCommand, MethodResult<CreatePlanAccountCommandResponse>>
    {
        private readonly IGroupAccountRepository _groupAccount;
        public CreatePlanAccountCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,IPlanAccountRepository planAccountRepository, IGroupAccountRepository groupAccount) : base(mapper, httpContextAccessor, planAccountRepository)
        {
            _groupAccount = groupAccount;
        }

        /// <summary>
        /// Handle for creating a new PlanAccount
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreatePlanAccountCommandResponse>> Handle(CreatePlanAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreatePlanAccountCommandResponse>();
            List<PlanAccount> newPlanAccounts = new List<PlanAccount>();
            var existingGroupAccounts = await _groupAccount.GetAllListAsync(x => x.GroupId == request.GroupId && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false);
            if (request.GroupId.HasValue && existingGroupAccounts.Count > 0)
            {
                foreach (var groupAccount in existingGroupAccounts)
                {
                    if (!await _planAccountRepository.AnyAsync(x => x.AccountId == groupAccount.AccountId && x.OwnerById == request.OwnerById && x.OwnerTable == request.OwnerTable && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false))
                    {
                        var newPlanAccount = new PlanAccount(request.AccountId, request.GroupId, request.PermistionId, request.OwnerById, request.OwnerTable);
                        newPlanAccount.SetCreate(_user);
                        newPlanAccount.Status = request.Status.HasValue ? request.Status : newPlanAccount.Status;
                        newPlanAccount.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                        newPlanAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
                        newPlanAccounts.Add(newPlanAccount);
                    }
                }
            }
            else if (request.AccountId > 0)
            {
                if (!await _planAccountRepository.AnyAsync(x => x.AccountId == request.AccountId && x.OwnerById == request.OwnerById && x.OwnerTable == request.OwnerTable && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false))
                {
                    var newPlanAccount = new PlanAccount(request.AccountId, request.GroupId, request.PermistionId, request.OwnerById, request.OwnerTable);
                    newPlanAccount.SetCreate(_user);
                    newPlanAccount.Status = request.Status.HasValue ? request.Status : newPlanAccount.Status;
                    newPlanAccount.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                    newPlanAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
                    newPlanAccounts.Add(newPlanAccount);
                }
            }
            await _planAccountRepository.AddRangeAsync(newPlanAccounts).ConfigureAwait(false);
            await _planAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var PlanAccountCommandResponseDTOs = _mapper.Map<List<PlanAccountCommandResponseDTO>>(newPlanAccounts);
            methodResult.Result = new CreatePlanAccountCommandResponse(PlanAccountCommandResponseDTOs);

            return methodResult;
        }
    }
}
