using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateDocumentReleasedAccountCommand : DocumentReleasedAccountCommandSet,IRequest<MethodResult<UpdateDocumentReleasedAccountCommandResponse>>
    {
       
    }

    public class UpdateDocumentReleasedAccountCommandResponse : DocumentReleasedAccountCommandResponseDTO
    {
    }
}