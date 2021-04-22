using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteSysJobParameterCommand : IRequest<MethodResult<DeleteSysJobParameterCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteSysJobParameterCommandResponse
    {
        public DeleteSysJobParameterCommandResponse(List<SysJobParameterCommandResponseDTO> SysJobParameter)
        {
            _SysJobParameter = SysJobParameter;
        }

        public List<SysJobParameterCommandResponseDTO> _SysJobParameter { get; }
    }
}
