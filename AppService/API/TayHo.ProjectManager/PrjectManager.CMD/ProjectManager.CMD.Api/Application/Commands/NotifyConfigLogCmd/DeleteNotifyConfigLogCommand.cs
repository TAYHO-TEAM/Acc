using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNotifyConfigLogCommand : IRequest<MethodResult<DeleteNotifyConfigLogCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNotifyConfigLogCommandResponse
    {
        public DeleteNotifyConfigLogCommandResponse(List<NotifyConfigLogCommandResponseDTO> NotifyConfigLog)
        {
            _NotifyConfigLog = NotifyConfigLog;
        }

        public List<NotifyConfigLogCommandResponseDTO> _NotifyConfigLog { get; }
    }
}
