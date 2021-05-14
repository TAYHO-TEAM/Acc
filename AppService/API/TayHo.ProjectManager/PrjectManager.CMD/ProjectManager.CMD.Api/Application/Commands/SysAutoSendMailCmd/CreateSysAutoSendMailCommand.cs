using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateSysAutoSendMailCommand : SysAutoSendMailCommandSet, IRequest<MethodResult<CreateSysAutoSendMailCommandResponse>>
    {
       
    }

    public class CreateSysAutoSendMailCommandResponse : SysAutoSendMailCommandResponseDTO { }
}
