using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateRequestDetailCommand :RequestDetailCommandSet, IRequest<MethodResult<CreateRequestDetailCommandResponse>>
    {
        
    }

    public class CreateRequestDetailCommandResponse : RequestDetailCommandResponseDTO { }
}