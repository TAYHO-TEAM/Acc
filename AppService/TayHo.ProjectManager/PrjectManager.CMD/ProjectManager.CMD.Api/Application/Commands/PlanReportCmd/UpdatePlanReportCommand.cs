using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdatePlanReportCommand : PlanReportCommandSet,IRequest<MethodResult<UpdatePlanReportCommandResponse>>
    {
       
    }

    public class UpdatePlanReportCommandResponse : PlanReportCommandResponseDTO
    {
    }
}
