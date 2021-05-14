using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_HangMucDetailCommand : NS_HangMucDetailCommandSet,IRequest<MethodResult<UpdateNS_HangMucDetailCommandResponse>>
    {
       
    }

    public class UpdateNS_HangMucDetailCommandResponse : NS_HangMucDetailCommandResponseDTO
    {
    }
}