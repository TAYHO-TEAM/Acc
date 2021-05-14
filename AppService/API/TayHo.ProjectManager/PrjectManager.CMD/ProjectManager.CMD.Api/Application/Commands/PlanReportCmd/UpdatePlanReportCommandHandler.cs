using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdatePlanReportCommandHandler : PlanReportCommandHandler,IRequestHandler<UpdatePlanReportCommand, MethodResult<UpdatePlanReportCommandResponse>>
    {
        public UpdatePlanReportCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor, IPlanReportRepository planReportRepository) : base(mapper,httpContextAccessor,planReportRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing PlanReport.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdatePlanReportCommandResponse>> Handle(UpdatePlanReportCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdatePlanReportCommandResponse>();
            var existingPlanReport = await _planReportRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanReport == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingPlanReport.IsActive = request.IsActive.HasValue ? request.IsActive : existingPlanReport.IsActive;
            existingPlanReport.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingPlanReport.IsVisible;
            existingPlanReport.Status = request.Status.HasValue ? request.Status : existingPlanReport.Status;

            existingPlanReport.SetPlanMasterId(request.PlanMasterId);
	existingPlanReport.SetPlanJobId(request.PlanJobId);
			existingPlanReport.SetContent(request.Content);
			existingPlanReport.SetUnit(request.Unit);
			existingPlanReport.SetAmount(request.Amount);
			

            existingPlanReport.SetUpdate(_user,null);
            _planReportRepository.Update(existingPlanReport);
            await _planReportRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdatePlanReportCommandResponse>(existingPlanReport);
            return methodResult;
        }
    }
}
