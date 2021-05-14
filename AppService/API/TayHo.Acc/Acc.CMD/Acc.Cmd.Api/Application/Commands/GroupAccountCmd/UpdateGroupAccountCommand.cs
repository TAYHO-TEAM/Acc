using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateGroupAccountCommand : GroupAccountCommandSet,IRequest<MethodResult<UpdateGroupAccountCommandResponse>>
    {
       
    }

    public class UpdateGroupAccountCommandResponse : GroupAccountCommandResponseDTO
    {
    }
}