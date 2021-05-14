using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteDocumentReleasedCommand : IRequest<MethodResult<DeleteDocumentReleasedCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteDocumentReleasedCommandResponse
    {
        public DeleteDocumentReleasedCommandResponse(List<DocumentReleasedCommandResponseDTO> DocumentReleased)
        {
            DocumentReleased = DocumentReleased;
        }

        public List<DocumentReleasedCommandResponseDTO> DocumentReleased { get; }
    }
}