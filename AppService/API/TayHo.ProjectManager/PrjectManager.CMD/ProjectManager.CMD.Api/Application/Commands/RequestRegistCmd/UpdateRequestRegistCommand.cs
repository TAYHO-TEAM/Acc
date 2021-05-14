using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateRequestRegistCommand : RequestRegistCommandSet,IRequest<MethodResult<UpdateRequestRegistCommandResponse>>
    {
       
    }

    public class UpdateRequestRegistCommandResponse : RequestRegistCommandResponseDTO
    {
    }
}