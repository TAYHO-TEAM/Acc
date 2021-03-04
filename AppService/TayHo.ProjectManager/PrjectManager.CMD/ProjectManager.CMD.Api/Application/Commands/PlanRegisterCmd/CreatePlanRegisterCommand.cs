using MediatR;
using Services.Common.DomainObjects;
using System;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanRegisterCommand : IRequest<MethodResult<CreatePlanRegisterCommandResponse>>
    {
        public List<PlanRegisterCommandSet> planRegisters { get; set; }
    }

    public class CreatePlanRegisterCommandResponse 
    {
        public CreatePlanRegisterCommandResponse(List<PlanRegisterCommandResponseDTO> PlanRegister)
        {
            _planRegister = PlanRegister;
        }

        public List<PlanRegisterCommandResponseDTO> _planRegister { get; }
    }
    //public class CreatePlanRegisterCommands 
    //{
    //    public List<CreatePlanRegisterCommand> _createPlanRegisterCommand { get; set; }
    //}
}