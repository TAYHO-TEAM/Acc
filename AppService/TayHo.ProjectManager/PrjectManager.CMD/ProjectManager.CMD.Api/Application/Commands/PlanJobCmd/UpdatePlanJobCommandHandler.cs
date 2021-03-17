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
    public class UpdatePlanJobCommandHandler : PlanJobCommandHandler, IRequestHandler<UpdatePlanJobCommand, MethodResult<UpdatePlanJobCommandResponse>>
    {
        public UpdatePlanJobCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IPlanJobRepository planJobRepository) : base(mapper, httpContextAccessor, planJobRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing PlanJob.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdatePlanJobCommandResponse>> Handle(UpdatePlanJobCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdatePlanJobCommandResponse>();
            var existingPlanJob = await _planJobRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanJob == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingPlanJob.IsActive = request.IsActive.HasValue ? request.IsActive : existingPlanJob.IsActive;
            existingPlanJob.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingPlanJob.IsVisible;
            existingPlanJob.Status = request.Status.HasValue ? request.Status : existingPlanJob.Status;

            existingPlanJob.SetPlanMasterId(request.PlanMasterId);
            existingPlanJob.SetParentId(request.ParentId);
            existingPlanJob.SetTitle(request.Title);
            existingPlanJob.SetDescription(request.Description);
            existingPlanJob.SetUnit(request.Unit);
            existingPlanJob.SetAmount(request.Amount);
            existingPlanJob.SetStartDate(request.StartDate);
            existingPlanJob.SetEndDate(request.EndDate);
            existingPlanJob.SetModifyTimes(request.ModifyTimes);
            existingPlanJob.SetPriority(request.Priority);
            existingPlanJob.SetImportantLevel(request.ImportantLevel);
            existingPlanJob.SetIsDone(request.IsDone);


            existingPlanJob.SetUpdate(_user, null);
            _planJobRepository.Update(existingPlanJob);
            await _planJobRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdatePlanJobCommandResponse>(existingPlanJob);
            return methodResult;
        }
    }
}
