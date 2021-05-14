using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeletePlanRegisterCommand : IRequest<MethodResult<DeletePlanRegisterCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeletePlanRegisterCommandResponse
    {
        public DeletePlanRegisterCommandResponse(List<PlanRegisterCommandResponseDTO> PlanRegister)
        {
            _PlanRegister = PlanRegister;
        }

        public List<PlanRegisterCommandResponseDTO> _PlanRegister { get; }
    }
}