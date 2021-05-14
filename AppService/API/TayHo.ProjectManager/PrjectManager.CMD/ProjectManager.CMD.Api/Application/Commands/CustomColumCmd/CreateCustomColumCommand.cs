using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateCustomColumCommand :CustomColumCommandSet, IRequest<MethodResult<CreateCustomColumCommandResponse>>
    {
        
    }

    public class CreateCustomColumCommandResponse : CustomColumCommandResponseDTO { }
}