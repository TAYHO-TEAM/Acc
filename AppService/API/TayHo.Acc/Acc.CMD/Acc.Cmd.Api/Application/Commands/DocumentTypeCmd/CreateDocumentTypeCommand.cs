using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateDocumentTypeCommand : DocumentTypeCommandSet, IRequest<MethodResult<CreateDocumentTypeCommandResponse>>
    {
       
    }

    public class CreateDocumentTypeCommandResponse : DocumentTypeCommandResponseDTO { }
}