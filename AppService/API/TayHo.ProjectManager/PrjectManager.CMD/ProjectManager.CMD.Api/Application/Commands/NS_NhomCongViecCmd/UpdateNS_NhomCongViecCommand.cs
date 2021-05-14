using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_NhomCongViecCommand : NS_NhomCongViecCommandSet,IRequest<MethodResult<UpdateNS_NhomCongViecCommandResponse>>
    {
       
    }

    public class UpdateNS_NhomCongViecCommandResponse : NS_NhomCongViecCommandResponseDTO
    {
    }
}
