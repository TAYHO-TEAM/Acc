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
    public class UpdatePlanAccountCommandHandler : PlanAccountCommandHandler,IRequestHandler<UpdatePlanAccountCommand, MethodResult<UpdatePlanAccountCommandResponse>>
    {
        public UpdatePlanAccountCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor, IPlanAccountRepository planAccountRepository) : base(mapper,httpContextAccessor,planAccountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing PlanAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdatePlanAccountCommandResponse>> Handle(UpdatePlanAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdatePlanAccountCommandResponse>();
            var existingPlanAccount = await _planAccountRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanAccount == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingPlanAccount.IsActive = request.IsActive.HasValue ? request.IsActive : existingPlanAccount.IsActive;
            existingPlanAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingPlanAccount.IsVisible;
            existingPlanAccount.Status = request.Status.HasValue ? request.Status : existingPlanAccount.Status;

            existingPlanAccount.SetAccountId(request.AccountId);
	existingPlanAccount.SetGroupId(request.GroupId);
			existingPlanAccount.SetPermistionId(request.PermistionId);
			existingPlanAccount.SetOwnerById(request.OwnerById);
			existingPlanAccount.SetOwnerTable(request.OwnerTable);
			

            existingPlanAccount.SetUpdate(_user,null);
            _planAccountRepository.Update(existingPlanAccount);
            await _planAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdatePlanAccountCommandResponse>(existingPlanAccount);
            return methodResult;
        }
    }
}
