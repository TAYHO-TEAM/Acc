using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateFormPlanMasterCommand : PlanMasterCommandSet, IRequest<MethodResult<CreateFormPlanMasterCommandResponse>>
    {
       
    }

    public class CreateFormPlanMasterCommandResponse : PlanMasterCommandResponseDTO { }
}
