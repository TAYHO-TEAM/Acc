using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteDocumentTypeCommand : IRequest<MethodResult<DeleteDocumentTypeCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteDocumentTypeCommandResponse
    {
        public DeleteDocumentTypeCommandResponse(List<DocumentTypeCommandResponseDTO> DocumentType)
        {
            documentType = DocumentType;
        }

        public List<DocumentTypeCommandResponseDTO> documentType { get; }
    }
}