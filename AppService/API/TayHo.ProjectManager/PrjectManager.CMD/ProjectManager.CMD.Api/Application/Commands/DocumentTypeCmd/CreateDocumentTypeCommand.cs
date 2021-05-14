using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateDocumentTypeCommand :DocumentTypeCommandSet, IRequest<MethodResult<CreateDocumentTypeCommandResponse>>
    {
        
    }

    public class CreateDocumentTypeCommandResponse : DocumentTypeCommandResponseDTO { }
}