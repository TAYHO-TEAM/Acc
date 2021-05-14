using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateConversationCommand : ConversationCommandSet,IRequest<MethodResult<UpdateConversationCommandResponse>>
    {
       
    }

    public class UpdateConversationCommandResponse : ConversationCommandResponseDTO
    {
    }
}
