using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_LoaiCongViecCommand : NS_LoaiCongViecCommandSet,IRequest<MethodResult<UpdateNS_LoaiCongViecCommandResponse>>
    {
       
    }

    public class UpdateNS_LoaiCongViecCommandResponse : NS_LoaiCongViecCommandResponseDTO
    {
    }
}
