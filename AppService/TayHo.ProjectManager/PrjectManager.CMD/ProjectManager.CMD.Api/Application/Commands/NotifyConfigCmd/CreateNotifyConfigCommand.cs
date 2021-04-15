using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNotifyConfigCommand : NotifyConfigCommandSet, IRequest<MethodResult<CreateNotifyConfigCommandResponse>>
    {
       
    }

    public class CreateNotifyConfigCommandResponse : NotifyConfigCommandResponseDTO { }
}
