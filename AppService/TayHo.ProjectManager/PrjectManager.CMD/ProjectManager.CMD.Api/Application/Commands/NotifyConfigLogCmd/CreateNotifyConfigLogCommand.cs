using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNotifyConfigLogCommand : NotifyConfigLogCommandSet, IRequest<MethodResult<CreateNotifyConfigLogCommandResponse>>
    {
       
    }

    public class CreateNotifyConfigLogCommandResponse : NotifyConfigLogCommandResponseDTO { }
}
