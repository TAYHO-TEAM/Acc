using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeletePlanScheduleCommand : IRequest<MethodResult<DeletePlanScheduleCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeletePlanScheduleCommandResponse
    {
        public DeletePlanScheduleCommandResponse(List<PlanScheduleCommandResponseDTO> PlanSchedule)
        {
            _PlanSchedule = PlanSchedule;
        }

        public List<PlanScheduleCommandResponseDTO> _PlanSchedule { get; }
    }
}
