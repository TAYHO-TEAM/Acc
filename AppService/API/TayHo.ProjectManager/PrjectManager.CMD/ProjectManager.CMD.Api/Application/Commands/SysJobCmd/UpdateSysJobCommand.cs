using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateSysJobCommand : SysJobCommandSet,IRequest<MethodResult<UpdateSysJobCommandResponse>>
    {
       
    }

    public class UpdateSysJobCommandResponse : SysJobCommandResponseDTO
    {
    }
}
