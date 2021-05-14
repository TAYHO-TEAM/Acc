using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateFilesAttachmentCommand :FilesAttachmentCommandSet, IRequest<MethodResult<CreateFilesAttachmentCommandResponse>>
    {
        
    }

    public class CreateFilesAttachmentCommandResponse : FilesAttachmentCommandResponseDTO { }
}