using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateResponseRegistReplyCommand : ResponseRegistReplyCommandSet,IRequest<MethodResult<UpdateResponseRegistReplyCommandResponse>>
    {
       
    }

    public class UpdateResponseRegistReplyCommandResponse : ResponseRegistReplyCommandResponseDTO
    {
    }
}