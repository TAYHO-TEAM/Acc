using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateResponseRegistCommand :ResponseRegistCommandSet, IRequest<MethodResult<CreateResponseRegistCommandResponse>>
    {
        
    }

    public class CreateResponseRegistCommandResponse : ResponseRegistCommandResponseDTO { }
}