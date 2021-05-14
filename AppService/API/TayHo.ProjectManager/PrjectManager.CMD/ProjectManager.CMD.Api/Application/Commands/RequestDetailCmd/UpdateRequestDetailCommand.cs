using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateRequestDetailCommand : RequestDetailCommandSet,IRequest<MethodResult<UpdateRequestDetailCommandResponse>>
    {
       
    }

    public class UpdateRequestDetailCommandResponse : RequestDetailCommandResponseDTO
    {
    }
}