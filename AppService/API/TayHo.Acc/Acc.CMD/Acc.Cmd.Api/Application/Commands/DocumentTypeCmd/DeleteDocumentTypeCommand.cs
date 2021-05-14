using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteDocumentTypeCommand : IRequest<MethodResult<DeleteDocumentTypeCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteDocumentTypeCommandResponse
    {
        public DeleteDocumentTypeCommandResponse(List<DocumentTypeCommandResponseDTO> DocumentType)
        {
            _DocumentType = DocumentType;
        }

        public List<DocumentTypeCommandResponseDTO> _DocumentType { get; }
    }
}