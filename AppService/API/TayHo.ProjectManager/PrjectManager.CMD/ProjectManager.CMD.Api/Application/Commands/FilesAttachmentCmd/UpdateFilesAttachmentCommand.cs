using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateFilesAttachmentCommand : FilesAttachmentCommandSet,IRequest<MethodResult<UpdateFilesAttachmentCommandResponse>>
    {
       
    }

    public class UpdateFilesAttachmentCommandResponse : FilesAttachmentCommandResponseDTO
    {
    }
}