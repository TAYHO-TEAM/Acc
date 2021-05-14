using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateDocumentReleasedLogCommand : DocumentReleasedLogCommandSet,IRequest<MethodResult<UpdateDocumentReleasedLogCommandResponse>>
    {
       
    }

    public class UpdateDocumentReleasedLogCommandResponse : DocumentReleasedLogCommandResponseDTO
    {
    }
}