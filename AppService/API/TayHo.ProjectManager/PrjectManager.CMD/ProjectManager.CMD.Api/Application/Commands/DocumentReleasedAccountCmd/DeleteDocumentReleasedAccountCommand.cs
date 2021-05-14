using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteDocumentReleasedAccountCommand : IRequest<MethodResult<DeleteDocumentReleasedAccountCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteDocumentReleasedAccountCommandResponse
    {
        public DeleteDocumentReleasedAccountCommandResponse(List<DocumentReleasedAccountCommandResponseDTO> DocumentReleasedAccount)
        {
            DocumentReleasedAccount = DocumentReleasedAccount;
        }

        public List<DocumentReleasedAccountCommandResponseDTO> DocumentReleasedAccount { get; }
    }
}