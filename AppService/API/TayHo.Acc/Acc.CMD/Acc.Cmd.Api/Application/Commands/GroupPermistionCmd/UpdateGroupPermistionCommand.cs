using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateGroupPermistionCommand : GroupPermistionCommandSet,IRequest<MethodResult<UpdateGroupPermistionCommandResponse>>
    {
       
    }

    public class UpdateGroupPermistionCommandResponse : GroupPermistionCommandResponseDTO
    {
    }
}