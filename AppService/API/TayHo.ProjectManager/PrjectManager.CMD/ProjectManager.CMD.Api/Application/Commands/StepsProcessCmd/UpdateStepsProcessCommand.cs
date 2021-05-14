using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateStepsProcessCommand : StepsProcessCommandSet,IRequest<MethodResult<UpdateStepsProcessCommandResponse>>
    {
       
    }

    public class UpdateStepsProcessCommandResponse : StepsProcessCommandResponseDTO
    {
    }
}