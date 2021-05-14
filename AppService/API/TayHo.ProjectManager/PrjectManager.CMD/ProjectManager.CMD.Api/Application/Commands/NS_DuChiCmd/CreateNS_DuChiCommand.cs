using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_DuChiCommand :NS_DuChiCommandSet, IRequest<MethodResult<CreateNS_DuChiCommandResponse>>
    {
        
    }

    public class CreateNS_DuChiCommandResponse : NS_DuChiCommandResponseDTO { }
}