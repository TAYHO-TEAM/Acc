using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_Phat_TheoDoiCommand : NS_Phat_TheoDoiCommandSet,IRequest<MethodResult<UpdateNS_Phat_TheoDoiCommandResponse>>
    {
       
    }

    public class UpdateNS_Phat_TheoDoiCommandResponse : NS_Phat_TheoDoiCommandResponseDTO
    {
    }
}