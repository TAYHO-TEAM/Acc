using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNotifyCommand : NotifyCommandSet,IRequest<MethodResult<UpdateNotifyCommandResponse>>
    {
       
    }

    public class UpdateNotifyCommandResponse : NotifyCommandResponseDTO
    {
    }
}
