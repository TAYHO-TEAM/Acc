using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteSysJobCommand : IRequest<MethodResult<DeleteSysJobCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteSysJobCommandResponse
    {
        public DeleteSysJobCommandResponse(List<SysJobCommandResponseDTO> SysJob)
        {
            _SysJob = SysJob;
        }

        public List<SysJobCommandResponseDTO> _SysJob { get; }
    }
}
