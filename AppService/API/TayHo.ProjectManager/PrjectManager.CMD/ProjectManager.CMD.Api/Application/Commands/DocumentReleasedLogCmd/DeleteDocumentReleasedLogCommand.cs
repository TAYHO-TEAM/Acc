using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteDocumentReleasedLogCommand : IRequest<MethodResult<DeleteDocumentReleasedLogCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteDocumentReleasedLogCommandResponse
    {
        public DeleteDocumentReleasedLogCommandResponse(List<DocumentReleasedLogCommandResponseDTO> DocumentReleasedLog)
        {
            DocumentReleasedLog = DocumentReleasedLog;
        }

        public List<DocumentReleasedLogCommandResponseDTO> DocumentReleasedLog { get; }
    }
}