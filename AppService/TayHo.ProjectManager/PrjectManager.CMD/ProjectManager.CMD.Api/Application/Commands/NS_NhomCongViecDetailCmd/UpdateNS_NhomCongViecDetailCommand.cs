using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_NhomCongViecDetailCommand : NS_NhomCongViecDetailCommandSet,IRequest<MethodResult<UpdateNS_NhomCongViecDetailCommandResponse>>
    {
       
    }

    public class UpdateNS_NhomCongViecDetailCommandResponse : NS_NhomCongViecDetailCommandResponseDTO
    {
    }
}
