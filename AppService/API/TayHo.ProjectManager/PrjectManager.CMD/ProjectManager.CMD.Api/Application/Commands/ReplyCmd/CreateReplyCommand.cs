using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateReplyCommand :ReplyCommandSet, IRequest<MethodResult<CreateReplyCommandResponse>>
    {
        
    }

    public class CreateReplyCommandResponse : ReplyCommandResponseDTO { }
}