using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupPermistionCommand : GroupPermistionCommandSet, IRequest<MethodResult<CreateGroupPermistionCommandResponse>>
    {
       
    }

    public class CreateGroupPermistionCommandResponse : GroupPermistionCommandResponseDTO { }
}