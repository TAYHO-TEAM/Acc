using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateConversationCommand : ConversationCommandSet, IRequest<MethodResult<CreateConversationCommandResponse>>
    {
       
    }

    public class CreateConversationCommandResponse : ConversationCommandResponseDTO { }
}
