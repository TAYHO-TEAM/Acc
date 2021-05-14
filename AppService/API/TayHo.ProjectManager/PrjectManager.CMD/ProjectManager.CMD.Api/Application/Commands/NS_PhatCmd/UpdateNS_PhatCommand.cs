using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_PhatCommand : NS_PhatCommandSet,IRequest<MethodResult<UpdateNS_PhatCommandResponse>>
    {
       
    }

    public class UpdateNS_PhatCommandResponse : NS_PhatCommandResponseDTO
    {
    }
}