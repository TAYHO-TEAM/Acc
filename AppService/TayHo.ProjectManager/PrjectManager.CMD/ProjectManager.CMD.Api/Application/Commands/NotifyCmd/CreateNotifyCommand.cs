using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNotifyCommand : NotifyCommandSet, IRequest<MethodResult<CreateNotifyCommandResponse>>
    {
       
    }

    public class CreateNotifyCommandResponse : NotifyCommandResponseDTO { }
}
