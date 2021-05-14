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
    public class DeletePlanAccountCommandHandler : PlanAccountCommandHandler, IRequestHandler<DeletePlanAccountCommand, MethodResult<DeletePlanAccountCommandResponse>>
    {
        public DeletePlanAccountCommandHandler(IMapper mapper, IPlanAccountRepository PlanAccountRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, PlanAccountRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing PlanAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeletePlanAccountCommandResponse>> Handle(DeletePlanAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeletePlanAccountCommandResponse>();
            var existingPlanAccounts = await _planAccountRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanAccounts == null || !existingPlanAccounts.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingPlanAccount in existingPlanAccounts)
            {
                existingPlanAccount.UpdateDate = now;
                existingPlanAccount.UpdateDateUTC = utc;
                existingPlanAccount.IsDelete = true;
                existingPlanAccount.SetUpdate(_user, null);
            }
            _planAccountRepository.UpdateRange(existingPlanAccounts);
            await _planAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var PlanAccountResponseDTOs = _mapper.Map<List<PlanAccountCommandResponseDTO>>(existingPlanAccounts);
            methodResult.Result = new DeletePlanAccountCommandResponse(PlanAccountResponseDTOs);
            return methodResult;
        }
    }
}
