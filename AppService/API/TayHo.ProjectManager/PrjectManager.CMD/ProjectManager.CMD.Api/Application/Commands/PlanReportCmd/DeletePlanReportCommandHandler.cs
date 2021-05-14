using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DeletePlanReportCommandHandler : PlanReportCommandHandler, IRequestHandler<DeletePlanReportCommand, MethodResult<DeletePlanReportCommandResponse>>
    {
        public DeletePlanReportCommandHandler(IMapper mapper, IPlanReportRepository PlanReportRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, PlanReportRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing PlanReport.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeletePlanReportCommandResponse>> Handle(DeletePlanReportCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeletePlanReportCommandResponse>();
            var existingPlanReports = await _planReportRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanReports == null || !existingPlanReports.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingPlanReport in existingPlanReports)
            {
                existingPlanReport.UpdateDate = now;
                existingPlanReport.UpdateDateUTC = utc;
                existingPlanReport.IsDelete = true;
                existingPlanReport.SetUpdate(_user, null);
            }
            _planReportRepository.UpdateRange(existingPlanReports);
            await _planReportRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var PlanReportResponseDTOs = _mapper.Map<List<PlanReportCommandResponseDTO>>(existingPlanReports);
            methodResult.Result = new DeletePlanReportCommandResponse(PlanReportResponseDTOs);
            return methodResult;
        }
    }
}
