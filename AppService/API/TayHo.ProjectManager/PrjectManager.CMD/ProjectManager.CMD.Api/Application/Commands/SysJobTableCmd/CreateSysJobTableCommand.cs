using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateSysJobTableCommand : SysJobTableCommandSet, IRequest<MethodResult<CreateSysJobTableCommandResponse>>
    {
       
    }

    public class CreateSysJobTableCommandResponse : SysJobTableCommandResponseDTO { }
}
