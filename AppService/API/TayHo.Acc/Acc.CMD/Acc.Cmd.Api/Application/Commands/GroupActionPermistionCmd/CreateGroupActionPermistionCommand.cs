using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupActionPermistionCommand : GroupActionPermistionCommandSet, IRequest<MethodResult<CreateGroupActionPermistionCommandResponse>>
    {
       
    }

    public class CreateGroupActionPermistionCommandResponse : GroupActionPermistionCommandResponseDTO { }
}