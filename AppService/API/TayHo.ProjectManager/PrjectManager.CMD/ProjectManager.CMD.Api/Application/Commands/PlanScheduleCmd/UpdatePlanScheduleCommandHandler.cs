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

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdatePlanScheduleCommandHandler : PlanScheduleCommandHandler, IRequestHandler<UpdatePlanScheduleCommand, MethodResult<UpdatePlanScheduleCommandResponse>>
    {
        public UpdatePlanScheduleCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IPlanScheduleRepository planScheduleRepository) : base(mapper, httpContextAccessor, planScheduleRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing PlanSchedule.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdatePlanScheduleCommandResponse>> Handle(UpdatePlanScheduleCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdatePlanScheduleCommandResponse>();
            var existingPlanSchedule = await _planScheduleRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanSchedule == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingPlanSchedule.IsActive = request.IsActive.HasValue ? request.IsActive : existingPlanSchedule.IsActive;
            existingPlanSchedule.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingPlanSchedule.IsVisible;
            existingPlanSchedule.Status = request.Status.HasValue ? request.Status : existingPlanSchedule.Status;

            existingPlanSchedule.SetPlanMasterId(request.PlanMasterId);
            existingPlanSchedule.SetPlanJobId(request.PlanJobId);
            existingPlanSchedule.SetTitle(request.Title);
            existingPlanSchedule.SetNote(request.Note);
            existingPlanSchedule.SetRemind(request.Remind);
            existingPlanSchedule.SetRepead(request.Repead);
            existingPlanSchedule.SetRepeadType(request.RepeadType);
            existingPlanSchedule.SetStartDate(request.StartDate);
            existingPlanSchedule.SetEndDate(request.EndDate);
            existingPlanSchedule.SetModifyTimes(request.ModifyTimes);


            existingPlanSchedule.SetUpdate(_user, null);
            _planScheduleRepository.Update(existingPlanSchedule);
            await _planScheduleRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdatePlanScheduleCommandResponse>(existingPlanSchedule);
            return methodResult;
        }
    }
}
