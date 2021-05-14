using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateStepsProcessCommand : StepsProcessCommandSet, IRequest<MethodResult<CreateStepsProcessCommandResponse>>
    {
       
    }

    public class CreateStepsProcessCommandResponse : StepsProcessCommandResponseDTO { }
}