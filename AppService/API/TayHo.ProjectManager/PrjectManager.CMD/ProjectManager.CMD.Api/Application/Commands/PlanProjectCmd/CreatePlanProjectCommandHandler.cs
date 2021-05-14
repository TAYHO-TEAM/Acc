using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanProjectCommandHandler : PlanProjectCommandHandler, IRequestHandler<CreatePlanProjectCommand, MethodResult<CreatePlanProjectCommandResponse>>
    {
        public CreatePlanProjectCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,IPlanProjectRepository planProjectRepository) : base(mapper, httpContextAccessor, planProjectRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new PlanProject
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreatePlanProjectCommandResponse>> Handle(CreatePlanProjectCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreatePlanProjectCommandResponse>();
            var newPlanProject = new PlanProject(request.Title,request.Description,request.Priority,request.ProjectId);
            newPlanProject.SetCreate(_user);
            newPlanProject.Status = request.Status.HasValue ? request.Status : newPlanProject.Status;
            newPlanProject.IsActive = request.IsActive.HasValue ? request.IsActive : true;
            newPlanProject.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
            await _planProjectRepository.AddAsync(newPlanProject).ConfigureAwait(false);
            await _planProjectRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreatePlanProjectCommandResponse>(newPlanProject);
            return methodResult;
        }
    }
}
