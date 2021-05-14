using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNotifyConfigLogCommand : NotifyConfigLogCommandSet,IRequest<MethodResult<UpdateNotifyConfigLogCommandResponse>>
    {
       
    }

    public class UpdateNotifyConfigLogCommandResponse : NotifyConfigLogCommandResponseDTO
    {
    }
}
