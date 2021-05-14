using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateResponseRegistReplyCommand :ResponseRegistReplyCommandSet, IRequest<MethodResult<CreateResponseRegistReplyCommandResponse>>
    {
        
    }

    public class CreateResponseRegistReplyCommandResponse : ResponseRegistReplyCommandResponseDTO { }
}