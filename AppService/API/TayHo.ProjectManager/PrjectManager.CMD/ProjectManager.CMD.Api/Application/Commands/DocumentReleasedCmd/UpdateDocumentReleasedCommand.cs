using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateDocumentReleasedCommand : DocumentReleasedCommandSet,IRequest<MethodResult<UpdateDocumentReleasedCommandResponse>>
    {
       
    }

    public class UpdateDocumentReleasedCommandResponse : DocumentReleasedCommandResponseDTO
    {
    }
}