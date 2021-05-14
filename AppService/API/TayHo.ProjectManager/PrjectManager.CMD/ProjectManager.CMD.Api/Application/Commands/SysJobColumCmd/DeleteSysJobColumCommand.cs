using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteSysJobColumCommand : IRequest<MethodResult<DeleteSysJobColumCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteSysJobColumCommandResponse
    {
        public DeleteSysJobColumCommandResponse(List<SysJobColumCommandResponseDTO> SysJobColum)
        {
            _SysJobColum = SysJobColum;
        }

        public List<SysJobColumCommandResponseDTO> _SysJobColum { get; }
    }
}
