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
    public class CreatePlanJobCommandHandler : PlanJobCommandHandler, IRequestHandler<CreatePlanJobCommand, MethodResult<CreatePlanJobCommandResponse>>
    {
        public CreatePlanJobCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,IPlanJobRepository planJobRepository) : base(mapper, httpContextAccessor, planJobRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new PlanJob
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreatePlanJobCommandResponse>> Handle(CreatePlanJobCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreatePlanJobCommandResponse>();
            var newPlanJob = new PlanJob(request.PlanMasterId,request.ParentId,request.Title,request.Description,request.Unit,request.Amount,request.StartDate,request.EndDate,request.ModifyTimes,request.Priority,request.ImportantLevel,request.IsDone);
            newPlanJob.SetCreate(_user);
            newPlanJob.Status = request.Status.HasValue ? request.Status : newPlanJob.Status;
            newPlanJob.IsActive = request.IsActive.HasValue ? request.IsActive : true;
            newPlanJob.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
            await _planJobRepository.AddAsync(newPlanJob).ConfigureAwait(false);
            await _planJobRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreatePlanJobCommandResponse>(newPlanJob);
            return methodResult;
        }
    }
}
