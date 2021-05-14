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
    public class DeletePlanScheduleCommandHandler : PlanScheduleCommandHandler, IRequestHandler<DeletePlanScheduleCommand, MethodResult<DeletePlanScheduleCommandResponse>>
    {
        public DeletePlanScheduleCommandHandler(IMapper mapper, IPlanScheduleRepository PlanScheduleRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, PlanScheduleRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing PlanSchedule.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeletePlanScheduleCommandResponse>> Handle(DeletePlanScheduleCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeletePlanScheduleCommandResponse>();
            var existingPlanSchedules = await _planScheduleRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanSchedules == null || !existingPlanSchedules.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingPlanSchedule in existingPlanSchedules)
            {
                existingPlanSchedule.UpdateDate = now;
                existingPlanSchedule.UpdateDateUTC = utc;
                existingPlanSchedule.IsDelete = true;
                existingPlanSchedule.SetUpdate(_user, null);
            }
            _planScheduleRepository.UpdateRange(existingPlanSchedules);
            await _planScheduleRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var PlanScheduleResponseDTOs = _mapper.Map<List<PlanScheduleCommandResponseDTO>>(existingPlanSchedules);
            methodResult.Result = new DeletePlanScheduleCommandResponse(PlanScheduleResponseDTOs);
            return methodResult;
        }
    }
}
