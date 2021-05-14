using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteSysJobTableCommand : IRequest<MethodResult<DeleteSysJobTableCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteSysJobTableCommandResponse
    {
        public DeleteSysJobTableCommandResponse(List<SysJobTableCommandResponseDTO> SysJobTable)
        {
            _SysJobTable = SysJobTable;
        }

        public List<SysJobTableCommandResponseDTO> _SysJobTable { get; }
    }
}
