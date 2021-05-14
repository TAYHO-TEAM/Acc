using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanScheduleCommand : PlanScheduleCommandSet, IRequest<MethodResult<CreatePlanScheduleCommandResponse>>
    {
       
    }

    public class CreatePlanScheduleCommandResponse : PlanScheduleCommandResponseDTO { }
}
