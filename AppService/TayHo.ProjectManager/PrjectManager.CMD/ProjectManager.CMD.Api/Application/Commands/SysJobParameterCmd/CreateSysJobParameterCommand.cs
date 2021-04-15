using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateSysJobParameterCommand : SysJobParameterCommandSet, IRequest<MethodResult<CreateSysJobParameterCommandResponse>>
    {
       
    }

    public class CreateSysJobParameterCommandResponse : SysJobParameterCommandResponseDTO { }
}
