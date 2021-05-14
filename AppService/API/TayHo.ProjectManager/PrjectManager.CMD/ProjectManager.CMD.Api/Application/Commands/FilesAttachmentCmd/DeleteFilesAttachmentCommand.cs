using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteFilesAttachmentCommand : IRequest<MethodResult<DeleteFilesAttachmentCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteFilesAttachmentCommandResponse
    {
        public DeleteFilesAttachmentCommandResponse(List<FilesAttachmentCommandResponseDTO> FilesAttachment)
        {
            filesAttachment = FilesAttachment;
        }

        public List<FilesAttachmentCommandResponseDTO> filesAttachment { get; }
    }
}