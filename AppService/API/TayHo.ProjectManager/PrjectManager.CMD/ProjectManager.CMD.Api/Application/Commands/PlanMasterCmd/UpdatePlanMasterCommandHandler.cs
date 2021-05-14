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
    public class UpdatePlanMasterCommandHandler : PlanMasterCommandHandler,IRequestHandler<UpdatePlanMasterCommand, MethodResult<UpdatePlanMasterCommandResponse>>
    {
        public UpdatePlanMasterCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor, IPlanMasterRepository planMasterRepository) : base(mapper,httpContextAccessor,planMasterRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing PlanMaster.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdatePlanMasterCommandResponse>> Handle(UpdatePlanMasterCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdatePlanMasterCommandResponse>();
            var existingPlanMaster = await _planMasterRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanMaster == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingPlanMaster.IsActive = request.IsActive.HasValue ? request.IsActive : existingPlanMaster.IsActive;
            existingPlanMaster.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingPlanMaster.IsVisible;
            existingPlanMaster.Status = request.Status.HasValue ? request.Status : existingPlanMaster.Status;

            existingPlanMaster.SetCode(request.Code);
	        existingPlanMaster.SetParentId(request.ParentId);
			existingPlanMaster.SetPlanProjectId(request.PlanProjectId);
			existingPlanMaster.SetTitle(request.Title);
			existingPlanMaster.SetTimeLine(request.TimeLine);
			existingPlanMaster.SetDescription(request.Description);
			existingPlanMaster.SetNote(request.Note);
			existingPlanMaster.SetStartDate(request.StartDate);
			existingPlanMaster.SetEndDate(request.EndDate);
			existingPlanMaster.SetUnit(request.Unit);
			existingPlanMaster.SetAmount(request.Amount);
			existingPlanMaster.SetReportPeriodicalType(request.ReportPeriodicalType);
			existingPlanMaster.SetReportPeriodical(request.ReportPeriodical);
			existingPlanMaster.SetReportFrequency(request.ReportFrequency);
			existingPlanMaster.SetPriority(request.Priority);
			existingPlanMaster.SetImportantLevel(request.ImportantLevel);
			existingPlanMaster.SetNoAttachment(request.NoAttachment);
			

            existingPlanMaster.SetUpdate(_user,null);
            _planMasterRepository.Update(existingPlanMaster);
            await _planMasterRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdatePlanMasterCommandResponse>(existingPlanMaster);
            return methodResult;
        }
    }
}
