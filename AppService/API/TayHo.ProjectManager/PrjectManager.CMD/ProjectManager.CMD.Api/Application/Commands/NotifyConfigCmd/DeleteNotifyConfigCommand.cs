using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNotifyConfigCommand : IRequest<MethodResult<DeleteNotifyConfigCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNotifyConfigCommandResponse
    {
        public DeleteNotifyConfigCommandResponse(List<NotifyConfigCommandResponseDTO> NotifyConfig)
        {
            _NotifyConfig = NotifyConfig;
        }

        public List<NotifyConfigCommandResponseDTO> _NotifyConfig { get; }
    }
}
