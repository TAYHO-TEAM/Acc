using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateReplyCommand : ReplyCommandSet,IRequest<MethodResult<UpdateReplyCommandResponse>>
    {
       
    }

    public class UpdateReplyCommandResponse : ReplyCommandResponseDTO
    {
    }
}