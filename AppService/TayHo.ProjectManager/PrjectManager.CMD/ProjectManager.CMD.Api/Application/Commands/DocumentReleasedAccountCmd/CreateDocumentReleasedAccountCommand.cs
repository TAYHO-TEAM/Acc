using MediatR;
using Services.Common.DomainObjects;
using System;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateDocumentReleasedAccountCommand :DocumentReleasedAccountCommandSet, IRequest<MethodResult<CreateDocumentReleasedAccountCommandResponse>>
    {
        
    }
    public class CreateDocumentReleasedAccountCommandResponse
    {
        public CreateDocumentReleasedAccountCommandResponse(List<DocumentReleasedAccountCommandResponseDTO> DocumentReleasedAccount)
        {
            _documentReleasedAccount = DocumentReleasedAccount;
        }

        public List<DocumentReleasedAccountCommandResponseDTO> _documentReleasedAccount { get; }
    }
    //public class CreateDocumentReleasedAccountCommandResponse : DocumentReleasedAccountCommandResponseDTO { }
}