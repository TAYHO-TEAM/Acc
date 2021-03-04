using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNotifyAccountCommand : NotifyAccountCommandSet,IRequest<MethodResult<UpdateNotifyAccountCommandResponse>>
    {
       
    }

    public class UpdateNotifyAccountCommandResponse : NotifyAccountCommandResponseDTO
    {
    }
}
