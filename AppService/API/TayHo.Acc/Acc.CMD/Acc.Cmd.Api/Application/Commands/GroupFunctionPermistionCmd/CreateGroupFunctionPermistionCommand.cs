using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupFunctionPermistionCommand : GroupFunctionPermistionCommandSet, IRequest<MethodResult<CreateGroupFunctionPermistionCommandResponse>>
    {
       
    }

    public class CreateGroupFunctionPermistionCommandResponse : GroupFunctionPermistionCommandResponseDTO { }
}