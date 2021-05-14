using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateSysJobColumCommand : SysJobColumCommandSet, IRequest<MethodResult<CreateSysJobColumCommandResponse>>
    {
       
    }

    public class CreateSysJobColumCommandResponse : SysJobColumCommandResponseDTO { }
}
