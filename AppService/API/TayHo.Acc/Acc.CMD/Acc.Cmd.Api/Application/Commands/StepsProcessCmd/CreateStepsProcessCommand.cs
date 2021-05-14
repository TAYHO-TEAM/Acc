using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateStepsProcessCommand : StepsProcessCommandSet, IRequest<MethodResult<CreateStepsProcessCommandResponse>>
    {
       
    }

    public class CreateStepsProcessCommandResponse : StepsProcessCommandResponseDTO { }
}