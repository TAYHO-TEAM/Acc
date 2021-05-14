using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteResponseRegistReplyCommand : IRequest<MethodResult<DeleteResponseRegistReplyCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteResponseRegistReplyCommandResponse
    {
        public DeleteResponseRegistReplyCommandResponse(List<ResponseRegistReplyCommandResponseDTO> ResponseRegistReply)
        {
            _ResponseRegistReply = ResponseRegistReply;
        }

        public List<ResponseRegistReplyCommandResponseDTO> _ResponseRegistReply { get; }
    }
}