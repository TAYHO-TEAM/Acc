using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanJobFullCommandHandler : PlanJobCommandHandler, IRequestHandler<CreatePlanJobFullCommand, MethodResult<CreatePlanJobCommandResponse>>
    {
        protected readonly IPlanScheduleRepository _planScheduleRepository;
        public CreatePlanJobFullCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,IPlanJobRepository planJobRepository, IPlanScheduleRepository planScheduleRepository) : base(mapper, httpContextAccessor, planJobRepository)
        {
            _planScheduleRepository = planScheduleRepository;
        }

        /// <summary>
        /// Handle for creating a new PlanJob
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreatePlanJobCommandResponse>> Handle(CreatePlanJobFullCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreatePlanJobCommandResponse>();
            var newPlanJob = new PlanJob(request.PlanMasterId,request.ParentId,request.Title,request.Description,request.Unit,request.Amount,request.StartDate,request.EndDate,request.ModifyTimes,request.Priority,request.ImportantLevel,request.IsDone);
            newPlanJob.SetCreate(_user);
            newPlanJob.Status = request.Status.HasValue ? request.Status : newPlanJob.Status;
            newPlanJob.IsActive = request.IsActive.HasValue ? request.IsActive : true;
            newPlanJob.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
            await _planJobRepository.AddAsync(newPlanJob).ConfigureAwait(false);
            await _planJobRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var newPlanSchedule = new PlanSchedule(request.PlanMasterId, newPlanJob.Id, request.planScheduleCommandSet.Title, request.planScheduleCommandSet.Note, request.planScheduleCommandSet.Remind, request.planScheduleCommandSet.Repead, request.planScheduleCommandSet.RepeadType, request.planScheduleCommandSet.StartDate, request.planScheduleCommandSet.EndDate, request.planScheduleCommandSet.ModifyTimes);
            newPlanSchedule.SetCreate(_user);
            await _planScheduleRepository.AddAsync(newPlanSchedule).ConfigureAwait(false);
            await _planScheduleRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreatePlanJobCommandResponse>(newPlanJob);
            return methodResult;
        }
    }
}
