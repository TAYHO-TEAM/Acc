using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_NhomCongViecCommand : NS_NhomCongViecCommandSet, IRequest<MethodResult<CreateNS_NhomCongViecCommandResponse>>
    {
       
    }

    public class CreateNS_NhomCongViecCommandResponse : NS_NhomCongViecCommandResponseDTO { }
}
