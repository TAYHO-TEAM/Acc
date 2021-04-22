using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNotifyConfigCommand : NotifyConfigCommandSet,IRequest<MethodResult<UpdateNotifyConfigCommandResponse>>
    {
       
    }

    public class UpdateNotifyConfigCommandResponse : NotifyConfigCommandResponseDTO
    {
    }
}
