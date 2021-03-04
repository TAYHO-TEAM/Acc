using MediatR;
using Services.Common.DomainObjects;
using System;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanAccountCommand : PlanAccountCommandSet, IRequest<MethodResult<CreatePlanAccountCommandResponse>>
    {
       
    }
    public class CreatePlanAccountCommandResponse
    {
        public CreatePlanAccountCommandResponse(List<PlanAccountCommandResponseDTO> PlanAccount)
        {
            _PlanAccount = PlanAccount;
        }

        public List<PlanAccountCommandResponseDTO> _PlanAccount { get; }
    }
    //public class CreatePlanAccountCommandResponse : PlanAccountCommandResponseDTO { }
}
