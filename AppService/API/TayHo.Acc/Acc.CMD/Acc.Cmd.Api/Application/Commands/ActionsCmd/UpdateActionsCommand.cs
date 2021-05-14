using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateActionsCommand : ActionsCommandSet,IRequest<MethodResult<UpdateActionsCommandResponse>>
    {
       
    }

    public class UpdateActionsCommandResponse : ActionsCommandResponseDTO
    {
    }
}