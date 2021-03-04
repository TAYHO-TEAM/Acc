using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdatePlanJobCommand : PlanJobCommandSet,IRequest<MethodResult<UpdatePlanJobCommandResponse>>
    {
       
    }

    public class UpdatePlanJobCommandResponse : PlanJobCommandResponseDTO
    {
    }
}
