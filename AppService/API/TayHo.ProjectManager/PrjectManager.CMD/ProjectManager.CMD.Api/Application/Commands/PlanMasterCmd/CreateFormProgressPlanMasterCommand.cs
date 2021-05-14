using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateFormProgressPlanMasterCommand : PlanMasterCommandSet, IRequest<MethodResult<CreateFormProgressPlanMasterCommandResponse>>
    {
       
    }
    public class CreateFormProgressPlanMasterCommandResponse : PlanMasterCommandResponseDTO { }
}
