using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_LoaiCongViecCommand : NS_LoaiCongViecCommandSet, IRequest<MethodResult<CreateNS_LoaiCongViecCommandResponse>>
    {
       
    }

    public class CreateNS_LoaiCongViecCommandResponse : NS_LoaiCongViecCommandResponseDTO { }
}
