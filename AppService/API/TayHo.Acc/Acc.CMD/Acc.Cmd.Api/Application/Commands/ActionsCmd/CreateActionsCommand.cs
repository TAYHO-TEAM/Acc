using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateActionsCommand : ActionsCommandSet, IRequest<MethodResult<CreateActionsCommandResponse>>
    {
       
    }

    public class CreateActionsCommandResponse : ActionsCommandResponseDTO { }
}