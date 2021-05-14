using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNotifyTemplateCommand : IRequest<MethodResult<DeleteNotifyTemplateCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNotifyTemplateCommandResponse
    {
        public DeleteNotifyTemplateCommandResponse(List<NotifyTemplateCommandResponseDTO> NotifyTemplate)
        {
            _NotifyTemplate = NotifyTemplate;
        }

        public List<NotifyTemplateCommandResponseDTO> _NotifyTemplate { get; }
    }
}
