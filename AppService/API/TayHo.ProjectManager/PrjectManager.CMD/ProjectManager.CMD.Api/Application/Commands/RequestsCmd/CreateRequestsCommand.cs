using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateRequestsCommand :RequestsCommandSet, IRequest<MethodResult<CreateRequestsCommandResponse>>
    {
        
    }

    public class CreateRequestsCommandResponse : RequestsCommandResponseDTO { }
}