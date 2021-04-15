using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateSysJobColumCommand : SysJobColumCommandSet,IRequest<MethodResult<UpdateSysJobColumCommandResponse>>
    {
       
    }

    public class UpdateSysJobColumCommandResponse : SysJobColumCommandResponseDTO
    {
    }
}
