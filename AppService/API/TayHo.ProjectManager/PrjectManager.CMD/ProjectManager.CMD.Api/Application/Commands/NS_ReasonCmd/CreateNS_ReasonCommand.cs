using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_ReasonCommand :NS_ReasonCommandSet, IRequest<MethodResult<CreateNS_ReasonCommandResponse>>
    {
        
    }

    public class CreateNS_ReasonCommandResponse : NS_ReasonCommandResponseDTO { }
}