using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateSysMailAccountCommand : SysMailAccountCommandSet,IRequest<MethodResult<UpdateSysMailAccountCommandResponse>>
    {
       
    }

    public class UpdateSysMailAccountCommandResponse : SysMailAccountCommandResponseDTO
    {
    }
}
