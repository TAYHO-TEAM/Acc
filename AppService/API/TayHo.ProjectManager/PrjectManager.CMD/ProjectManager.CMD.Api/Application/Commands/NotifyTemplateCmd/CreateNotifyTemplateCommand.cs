using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNotifyTemplateCommand : NotifyTemplateCommandSet, IRequest<MethodResult<CreateNotifyTemplateCommandResponse>>
    {
       
    }

    public class CreateNotifyTemplateCommandResponse : NotifyTemplateCommandResponseDTO { }
}
