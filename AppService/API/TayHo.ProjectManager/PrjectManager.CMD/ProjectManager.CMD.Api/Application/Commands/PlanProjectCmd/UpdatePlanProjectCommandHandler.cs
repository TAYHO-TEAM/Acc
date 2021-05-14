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
    public class UpdatePlanProjectCommandHandler : PlanProjectCommandHandler,IRequestHandler<UpdatePlanProjectCommand, MethodResult<UpdatePlanProjectCommandResponse>>
    {
        public UpdatePlanProjectCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor, IPlanProjectRepository planProjectRepository) : base(mapper,httpContextAccessor,planProjectRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing PlanProject.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdatePlanProjectCommandResponse>> Handle(UpdatePlanProjectCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdatePlanProjectCommandResponse>();
            var existingPlanProject = await _planProjectRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanProject == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingPlanProject.IsActive = request.IsActive.HasValue ? request.IsActive : existingPlanProject.IsActive;
            existingPlanProject.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingPlanProject.IsVisible;
            existingPlanProject.Status = request.Status.HasValue ? request.Status : existingPlanProject.Status;

            existingPlanProject.SetTitle(request.Title);
	existingPlanProject.SetDescription(request.Description);
			existingPlanProject.SetPriority(request.Priority);
			existingPlanProject.SetProjectId(request.ProjectId);
			

            existingPlanProject.SetUpdate(_user,null);
            _planProjectRepository.Update(existingPlanProject);
            await _planProjectRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdatePlanProjectCommandResponse>(existingPlanProject);
            return methodResult;
        }
    }
}
