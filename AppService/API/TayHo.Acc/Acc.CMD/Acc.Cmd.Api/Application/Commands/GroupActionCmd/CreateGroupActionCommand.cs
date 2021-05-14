using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupActionCommand : GroupActionCommandSet, IRequest<MethodResult<CreateGroupActionCommandResponse>>
    {
       
    }

    public class CreateGroupActionCommandResponse : GroupActionCommandResponseDTO { }
}