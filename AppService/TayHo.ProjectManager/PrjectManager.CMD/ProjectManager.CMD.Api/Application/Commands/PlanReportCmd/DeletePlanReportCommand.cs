using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeletePlanReportCommand : IRequest<MethodResult<DeletePlanReportCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeletePlanReportCommandResponse
    {
        public DeletePlanReportCommandResponse(List<PlanReportCommandResponseDTO> PlanReport)
        {
            _PlanReport = PlanReport;
        }

        public List<PlanReportCommandResponseDTO> _PlanReport { get; }
    }
}
