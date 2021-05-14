using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanMasterCommand : PlanMasterCommandSet, IRequest<MethodResult<CreatePlanMasterCommandResponse>>
    {
       
    }

    public class CreatePlanMasterCommandResponse : PlanMasterCommandResponseDTO { }
}
