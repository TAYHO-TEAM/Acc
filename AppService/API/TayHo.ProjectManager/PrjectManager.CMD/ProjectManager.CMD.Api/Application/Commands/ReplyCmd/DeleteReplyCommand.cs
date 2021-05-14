using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteReplyCommand : IRequest<MethodResult<DeleteReplyCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteReplyCommandResponse
    {
        public DeleteReplyCommandResponse(List<ReplyCommandResponseDTO> Reply)
        {
            reply = Reply;
        }

        public List<ReplyCommandResponseDTO> reply { get; }
    }
}