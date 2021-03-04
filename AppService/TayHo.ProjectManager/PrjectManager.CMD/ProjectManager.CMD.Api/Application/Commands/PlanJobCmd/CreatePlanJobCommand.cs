using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanJobCommand : PlanJobCommandSet, IRequest<MethodResult<CreatePlanJobCommandResponse>>
    {
       
    }

    public class CreatePlanJobCommandResponse : PlanJobCommandResponseDTO { }
}
