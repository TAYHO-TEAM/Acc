using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanReportCommand : PlanReportCommandSet, IRequest<MethodResult<CreatePlanReportCommandResponse>>
    {
       
    }

    public class CreatePlanReportCommandResponse : PlanReportCommandResponseDTO { }
}
