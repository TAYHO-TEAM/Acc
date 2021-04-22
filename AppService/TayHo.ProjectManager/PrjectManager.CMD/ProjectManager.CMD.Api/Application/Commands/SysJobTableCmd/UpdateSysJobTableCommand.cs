using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateSysJobTableCommand : SysJobTableCommandSet,IRequest<MethodResult<UpdateSysJobTableCommandResponse>>
    {
       
    }

    public class UpdateSysJobTableCommandResponse : SysJobTableCommandResponseDTO
    {
    }
}
