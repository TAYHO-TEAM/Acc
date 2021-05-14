using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNotifyCommand : IRequest<MethodResult<DeleteNotifyCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNotifyCommandResponse
    {
        public DeleteNotifyCommandResponse(List<NotifyCommandResponseDTO> Notify)
        {
            _Notify = Notify;
        }

        public List<NotifyCommandResponseDTO> _Notify { get; }
    }
}
