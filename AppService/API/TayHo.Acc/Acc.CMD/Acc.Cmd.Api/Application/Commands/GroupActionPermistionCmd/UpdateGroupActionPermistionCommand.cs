using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateGroupActionPermistionCommand : GroupActionPermistionCommandSet,IRequest<MethodResult<UpdateGroupActionPermistionCommandResponse>>
    {
       
    }

    public class UpdateGroupActionPermistionCommandResponse : GroupActionPermistionCommandResponseDTO
    {
    }
}