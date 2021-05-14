using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_CongViecDetailCommand :NS_CongViecDetailCommandSet, IRequest<MethodResult<CreateNS_CongViecDetailCommandResponse>>
    {
        
    }

    public class CreateNS_CongViecDetailCommandResponse : NS_CongViecDetailCommandResponseDTO { }
}