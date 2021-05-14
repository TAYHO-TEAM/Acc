using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateDocumentTypeCommand : DocumentTypeCommandSet,IRequest<MethodResult<UpdateDocumentTypeCommandResponse>>
    {
       
    }

    public class UpdateDocumentTypeCommandResponse : DocumentTypeCommandResponseDTO
    {
    }
}