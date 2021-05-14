using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_ThucChiCommand :NS_ThucChiCommandSet, IRequest<MethodResult<CreateNS_ThucChiCommandResponse>>
    {
        
    }

    public class CreateNS_ThucChiCommandResponse : NS_ThucChiCommandResponseDTO { }
}