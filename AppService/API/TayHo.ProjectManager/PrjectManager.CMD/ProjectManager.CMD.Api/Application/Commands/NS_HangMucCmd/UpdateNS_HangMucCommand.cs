using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_HangMucCommand : NS_HangMucCommandSet,IRequest<MethodResult<UpdateNS_HangMucCommandResponse>>
    {
       
    }

    public class UpdateNS_HangMucCommandResponse : NS_HangMucCommandResponseDTO
    {
    }
}