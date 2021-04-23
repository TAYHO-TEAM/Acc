using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_NhomCongViecDetailCommand : NS_NhomCongViecDetailCommandSet, IRequest<MethodResult<CreateNS_NhomCongViecDetailCommandResponse>>
    {
       
    }

    public class CreateNS_NhomCongViecDetailCommandResponse : NS_NhomCongViecDetailCommandResponseDTO { }
}
