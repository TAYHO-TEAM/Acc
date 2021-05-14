using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreatePermistionsCommand : PermistionsCommandSet, IRequest<MethodResult<CreatePermistionsCommandResponse>>
    {
       
    }

    public class CreatePermistionsCommandResponse : PermistionsCommandResponseDTO { }
}