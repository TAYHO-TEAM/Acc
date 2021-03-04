using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeletePlanAccountCommand : IRequest<MethodResult<DeletePlanAccountCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeletePlanAccountCommandResponse
    {
        public DeletePlanAccountCommandResponse(List<PlanAccountCommandResponseDTO> PlanAccount)
        {
            _PlanAccount = PlanAccount;
        }

        public List<PlanAccountCommandResponseDTO> _PlanAccount { get; }
    }
}
