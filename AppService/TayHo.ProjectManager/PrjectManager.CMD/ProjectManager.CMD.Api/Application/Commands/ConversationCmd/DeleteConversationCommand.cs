using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteConversationCommand : IRequest<MethodResult<DeleteConversationCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteConversationCommandResponse
    {
        public DeleteConversationCommandResponse(List<ConversationCommandResponseDTO> Conversation)
        {
            _Conversation = Conversation;
        }

        public List<ConversationCommandResponseDTO> _Conversation { get; }
    }
}
