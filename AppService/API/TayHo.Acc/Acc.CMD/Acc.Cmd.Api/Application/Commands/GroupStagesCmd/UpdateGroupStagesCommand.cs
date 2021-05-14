using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateGroupStagesCommand : GroupStagesCommandSet,IRequest<MethodResult<UpdateGroupStagesCommandResponse>>
    {
       
    }

    public class UpdateGroupStagesCommandResponse : GroupStagesCommandResponseDTO
    {
    }
}