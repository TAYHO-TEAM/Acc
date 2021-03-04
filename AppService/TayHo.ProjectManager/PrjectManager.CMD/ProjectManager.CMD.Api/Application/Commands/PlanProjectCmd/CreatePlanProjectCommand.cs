using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanProjectCommand : PlanProjectCommandSet, IRequest<MethodResult<CreatePlanProjectCommandResponse>>
    {
       
    }

    public class CreatePlanProjectCommandResponse : PlanProjectCommandResponseDTO { }
}
