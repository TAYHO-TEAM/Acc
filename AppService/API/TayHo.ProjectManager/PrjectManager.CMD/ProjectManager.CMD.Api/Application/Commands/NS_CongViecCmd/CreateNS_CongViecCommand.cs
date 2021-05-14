using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_CongViecCommand : NS_CongViecCommandSet, IRequest<MethodResult<CreateNS_CongViecCommandResponse>>
    {
       
    }

    public class CreateNS_CongViecCommandResponse : NS_CongViecCommandResponseDTO { }
}
