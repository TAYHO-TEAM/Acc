using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_CongViecCommand : NS_CongViecCommandSet,IRequest<MethodResult<UpdateNS_CongViecCommandResponse>>
    {
       
    }

    public class UpdateNS_CongViecCommandResponse : NS_CongViecCommandResponseDTO
    {
    }
}
