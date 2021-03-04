using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeletePlanJobCommand : IRequest<MethodResult<DeletePlanJobCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeletePlanJobCommandResponse
    {
        public DeletePlanJobCommandResponse(List<PlanJobCommandResponseDTO> PlanJob)
        {
            _PlanJob = PlanJob;
        }

        public List<PlanJobCommandResponseDTO> _PlanJob { get; }
    }
}
