using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNotifyTemplateCommand : NotifyTemplateCommandSet,IRequest<MethodResult<UpdateNotifyTemplateCommandResponse>>
    {
       
    }

    public class UpdateNotifyTemplateCommandResponse : NotifyTemplateCommandResponseDTO
    {
    }
}
