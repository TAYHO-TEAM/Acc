using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdatePlanAccountCommand : PlanAccountCommandSet,IRequest<MethodResult<UpdatePlanAccountCommandResponse>>
    {
       
    }

    public class UpdatePlanAccountCommandResponse : PlanAccountCommandResponseDTO
    {
    }
}
