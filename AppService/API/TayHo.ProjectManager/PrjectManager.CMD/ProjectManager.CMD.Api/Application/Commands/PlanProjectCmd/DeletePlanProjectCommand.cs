using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeletePlanProjectCommand : IRequest<MethodResult<DeletePlanProjectCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeletePlanProjectCommandResponse
    {
        public DeletePlanProjectCommandResponse(List<PlanProjectCommandResponseDTO> PlanProject)
        {
            _PlanProject = PlanProject;
        }

        public List<PlanProjectCommandResponseDTO> _PlanProject { get; }
    }
}
