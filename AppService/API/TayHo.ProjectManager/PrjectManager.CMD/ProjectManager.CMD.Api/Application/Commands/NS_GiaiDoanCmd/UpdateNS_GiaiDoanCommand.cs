using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_GiaiDoanCommand : NS_GiaiDoanCommandSet,IRequest<MethodResult<UpdateNS_GiaiDoanCommandResponse>>
    {
       
    }

    public class UpdateNS_GiaiDoanCommandResponse : NS_GiaiDoanCommandResponseDTO
    {
    }
}
