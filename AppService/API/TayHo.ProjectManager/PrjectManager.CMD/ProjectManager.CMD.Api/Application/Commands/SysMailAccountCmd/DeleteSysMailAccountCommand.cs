using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteSysMailAccountCommand : IRequest<MethodResult<DeleteSysMailAccountCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteSysMailAccountCommandResponse
    {
        public DeleteSysMailAccountCommandResponse(List<SysMailAccountCommandResponseDTO> SysMailAccount)
        {
            _SysMailAccount = SysMailAccount;
        }

        public List<SysMailAccountCommandResponseDTO> _SysMailAccount { get; }
    }
}
