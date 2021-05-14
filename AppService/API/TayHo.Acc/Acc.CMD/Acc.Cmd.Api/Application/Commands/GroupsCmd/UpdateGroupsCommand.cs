using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateGroupsCommand : GroupsCommandSet,IRequest<MethodResult<UpdateGroupsCommandResponse>>
    {
       
    }

    public class UpdateGroupsCommandResponse : GroupsCommandResponseDTO
    {
    }
}