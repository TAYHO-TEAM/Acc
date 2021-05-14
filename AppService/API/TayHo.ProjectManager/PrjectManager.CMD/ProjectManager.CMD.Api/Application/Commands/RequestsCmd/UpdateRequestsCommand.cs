using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateRequestsCommand : RequestsCommandSet,IRequest<MethodResult<UpdateRequestsCommandResponse>>
    {
       
    }

    public class UpdateRequestsCommandResponse : RequestsCommandResponseDTO
    {
    }
}