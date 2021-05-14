using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_PhatCommand :NS_PhatCommandSet, IRequest<MethodResult<CreateNS_PhatCommandResponse>>
    {
        
    }

    public class CreateNS_PhatCommandResponse : NS_PhatCommandResponseDTO { }
}