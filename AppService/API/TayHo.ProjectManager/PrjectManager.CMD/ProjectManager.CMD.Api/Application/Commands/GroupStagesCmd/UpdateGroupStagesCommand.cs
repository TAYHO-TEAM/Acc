using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateGroupStagesCommand : GroupStagesCommandSet,IRequest<MethodResult<UpdateGroupStagesCommandResponse>>
    {
       
    }

    public class UpdateGroupStagesCommandResponse : GroupStagesCommandResponseDTO
    {
    }
}