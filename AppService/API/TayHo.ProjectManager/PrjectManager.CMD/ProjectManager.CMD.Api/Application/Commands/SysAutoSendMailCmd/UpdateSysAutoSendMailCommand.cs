using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateSysAutoSendMailCommand : SysAutoSendMailCommandSet,IRequest<MethodResult<UpdateSysAutoSendMailCommandResponse>>
    {
       
    }

    public class UpdateSysAutoSendMailCommandResponse : SysAutoSendMailCommandResponseDTO
    {
    }
}
