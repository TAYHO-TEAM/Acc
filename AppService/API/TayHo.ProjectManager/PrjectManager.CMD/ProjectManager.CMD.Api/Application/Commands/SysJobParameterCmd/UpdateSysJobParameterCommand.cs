using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateSysJobParameterCommand : SysJobParameterCommandSet,IRequest<MethodResult<UpdateSysJobParameterCommandResponse>>
    {
       
    }

    public class UpdateSysJobParameterCommandResponse : SysJobParameterCommandResponseDTO
    {
    }
}
