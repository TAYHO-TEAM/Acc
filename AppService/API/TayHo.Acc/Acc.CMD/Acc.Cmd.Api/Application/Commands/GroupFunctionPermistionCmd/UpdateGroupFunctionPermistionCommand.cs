using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateGroupFunctionPermistionCommand : GroupFunctionPermistionCommandSet,IRequest<MethodResult<UpdateGroupFunctionPermistionCommandResponse>>
    {
       
    }

    public class UpdateGroupFunctionPermistionCommandResponse : GroupFunctionPermistionCommandResponseDTO
    {
    }
}