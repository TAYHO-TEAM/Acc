using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNotifyAccountCommand : IRequest<MethodResult<DeleteNotifyAccountCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNotifyAccountCommandResponse
    {
        public DeleteNotifyAccountCommandResponse(List<NotifyAccountCommandResponseDTO> NotifyAccount)
        {
            _NotifyAccount = NotifyAccount;
        }

        public List<NotifyAccountCommandResponseDTO> _NotifyAccount { get; }
    }
}
