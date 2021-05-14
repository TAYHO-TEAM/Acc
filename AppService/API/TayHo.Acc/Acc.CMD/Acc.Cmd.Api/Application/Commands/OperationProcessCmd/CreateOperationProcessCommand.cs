using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateOperationProcessCommand : OperationProcessCommandSet, IRequest<MethodResult<CreateOperationProcessCommandResponse>>
    {
       
    }

    public class CreateOperationProcessCommandResponse : OperationProcessCommandResponseDTO { }
}