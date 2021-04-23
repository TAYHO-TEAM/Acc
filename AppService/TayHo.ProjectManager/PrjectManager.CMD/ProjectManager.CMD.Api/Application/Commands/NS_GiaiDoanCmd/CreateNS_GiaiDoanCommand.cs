using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_GiaiDoanCommand : NS_GiaiDoanCommandSet, IRequest<MethodResult<CreateNS_GiaiDoanCommandResponse>>
    {
       
    }

    public class CreateNS_GiaiDoanCommandResponse : NS_GiaiDoanCommandResponseDTO { }
}
