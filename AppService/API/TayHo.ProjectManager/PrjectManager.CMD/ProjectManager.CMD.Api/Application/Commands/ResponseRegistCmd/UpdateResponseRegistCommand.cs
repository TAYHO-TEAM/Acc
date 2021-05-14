using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateResponseRegistCommand : ResponseRegistCommandSet,IRequest<MethodResult<UpdateResponseRegistCommandResponse>>
    {
       
    }

    public class UpdateResponseRegistCommandResponse : ResponseRegistCommandResponseDTO
    {
    }
}