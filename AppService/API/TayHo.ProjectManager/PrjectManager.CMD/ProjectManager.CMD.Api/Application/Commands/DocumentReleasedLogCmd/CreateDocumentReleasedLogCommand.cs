using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateDocumentReleasedLogCommand :DocumentReleasedLogCommandSet, IRequest<MethodResult<CreateDocumentReleasedLogCommandResponse>>
    {
        
    }

    public class CreateDocumentReleasedLogCommandResponse : DocumentReleasedLogCommandResponseDTO { }
}