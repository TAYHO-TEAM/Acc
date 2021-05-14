using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateDocumentTypeCommand : DocumentTypeCommandSet,IRequest<MethodResult<UpdateDocumentTypeCommandResponse>>
    {
       
    }

    public class UpdateDocumentTypeCommandResponse : DocumentTypeCommandResponseDTO
    {
    }
}