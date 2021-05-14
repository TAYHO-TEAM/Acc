using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_CongViecDetailCommand : NS_CongViecDetailCommandSet,IRequest<MethodResult<UpdateNS_CongViecDetailCommandResponse>>
    {
       
    }

    public class UpdateNS_CongViecDetailCommandResponse : NS_CongViecDetailCommandResponseDTO
    {
    }
}