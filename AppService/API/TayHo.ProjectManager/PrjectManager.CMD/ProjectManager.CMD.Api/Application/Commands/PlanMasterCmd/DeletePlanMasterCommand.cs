using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeletePlanMasterCommand : IRequest<MethodResult<DeletePlanMasterCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeletePlanMasterCommandResponse
    {
        public DeletePlanMasterCommandResponse(List<PlanMasterCommandResponseDTO> PlanMaster)
        {
            _PlanMaster = PlanMaster;
        }

        public List<PlanMasterCommandResponseDTO> _PlanMaster { get; }
    }
}
