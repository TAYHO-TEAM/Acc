using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_ReasonCommand : NS_ReasonCommandSet,IRequest<MethodResult<UpdateNS_ReasonCommandResponse>>
    {
       
    }

    public class UpdateNS_ReasonCommandResponse : NS_ReasonCommandResponseDTO
    {
    }
}