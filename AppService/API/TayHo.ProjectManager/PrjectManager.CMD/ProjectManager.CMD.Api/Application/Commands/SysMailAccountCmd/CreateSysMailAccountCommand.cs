using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateSysMailAccountCommand : SysMailAccountCommandSet, IRequest<MethodResult<CreateSysMailAccountCommandResponse>>
    {
       
    }

    public class CreateSysMailAccountCommandResponse : SysMailAccountCommandResponseDTO { }
}
