using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdatePlanScheduleCommand : PlanScheduleCommandSet,IRequest<MethodResult<UpdatePlanScheduleCommandResponse>>
    {
       
    }

    public class UpdatePlanScheduleCommandResponse : PlanScheduleCommandResponseDTO
    {
    }
}
