using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanScheduleCommandHandler : PlanScheduleCommandHandler, IRequestHandler<CreatePlanScheduleCommand, MethodResult<CreatePlanScheduleCommandResponse>>
    {
        public CreatePlanScheduleCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,IPlanScheduleRepository planScheduleRepository) : base(mapper, httpContextAccessor, planScheduleRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new PlanSchedule
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreatePlanScheduleCommandResponse>> Handle(CreatePlanScheduleCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreatePlanScheduleCommandResponse>();
            var newPlanSchedule = new PlanSchedule(request.PlanMasterId,request.PlanJobId,request.Title,request.Note,request.Remind,request.Repead,request.RepeadType,request.StartDate,request.EndDate,request.ModifyTimes);
            newPlanSchedule.SetCreate(_user);
            newPlanSchedule.Status = request.Status.HasValue ? request.Status : newPlanSchedule.Status;
            newPlanSchedule.IsActive = request.IsActive.HasValue ? request.IsActive : true;
            newPlanSchedule.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
            await _planScheduleRepository.AddAsync(newPlanSchedule).ConfigureAwait(false);
            await _planScheduleRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreatePlanScheduleCommandResponse>(newPlanSchedule);
            return methodResult;
        }
    }
}
