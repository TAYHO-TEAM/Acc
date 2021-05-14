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
    public class DeletePlanMasterCommandHandler : PlanMasterCommandHandler, IRequestHandler<DeletePlanMasterCommand, MethodResult<DeletePlanMasterCommandResponse>>
    {
        public DeletePlanMasterCommandHandler(IMapper mapper, IPlanMasterRepository PlanMasterRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, PlanMasterRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing PlanMaster.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeletePlanMasterCommandResponse>> Handle(DeletePlanMasterCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeletePlanMasterCommandResponse>();
            var existingPlanMasters = await _planMasterRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanMasters == null || !existingPlanMasters.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingPlanMaster in existingPlanMasters)
            {
                existingPlanMaster.UpdateDate = now;
                existingPlanMaster.UpdateDateUTC = utc;
                existingPlanMaster.IsDelete = true;
                existingPlanMaster.SetUpdate(_user, null);
            }
            _planMasterRepository.UpdateRange(existingPlanMasters);
            await _planMasterRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var PlanMasterResponseDTOs = _mapper.Map<List<PlanMasterCommandResponseDTO>>(existingPlanMasters);
            methodResult.Result = new DeletePlanMasterCommandResponse(PlanMasterResponseDTOs);
            return methodResult;
        }
    }
}
