using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateSysJobCommand : SysJobCommandSet, IRequest<MethodResult<CreateSysJobCommandResponse>>
    {
       
    }

    public class CreateSysJobCommandResponse : SysJobCommandResponseDTO { }
}
