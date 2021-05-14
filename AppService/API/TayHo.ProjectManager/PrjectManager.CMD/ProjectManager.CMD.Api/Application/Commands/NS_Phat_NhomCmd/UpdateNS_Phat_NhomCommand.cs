using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_Phat_NhomCommand : NS_Phat_NhomCommandSet,IRequest<MethodResult<UpdateNS_Phat_NhomCommandResponse>>
    {
       
    }

    public class UpdateNS_Phat_NhomCommandResponse : NS_Phat_NhomCommandResponseDTO
    {
    }
}
