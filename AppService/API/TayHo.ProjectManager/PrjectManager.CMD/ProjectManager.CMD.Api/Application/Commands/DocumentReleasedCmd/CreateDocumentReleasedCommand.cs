using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateDocumentReleasedCommand :DocumentReleasedCommandSet, IRequest<MethodResult<CreateDocumentReleasedCommandResponse>>
    {
        
    }

    public class CreateDocumentReleasedCommandResponse : DocumentReleasedCommandResponseDTO { }
}