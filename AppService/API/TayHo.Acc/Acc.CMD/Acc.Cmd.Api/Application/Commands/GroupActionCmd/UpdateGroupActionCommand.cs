using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateGroupActionCommand : GroupActionCommandSet,IRequest<MethodResult<UpdateGroupActionCommandResponse>>
    {
       
    }

    public class UpdateGroupActionCommandResponse : GroupActionCommandResponseDTO
    {
    }
}