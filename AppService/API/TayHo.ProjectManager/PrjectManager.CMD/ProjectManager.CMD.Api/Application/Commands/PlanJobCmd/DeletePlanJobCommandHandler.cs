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
    public class DeletePlanJobCommandHandler : PlanJobCommandHandler, IRequestHandler<DeletePlanJobCommand, MethodResult<DeletePlanJobCommandResponse>>
    {
        public DeletePlanJobCommandHandler(IMapper mapper, IPlanJobRepository PlanJobRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, PlanJobRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing PlanJob.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeletePlanJobCommandResponse>> Handle(DeletePlanJobCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeletePlanJobCommandResponse>();
            var existingPlanJobs = await _planJobRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanJobs == null || !existingPlanJobs.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingPlanJob in existingPlanJobs)
            {
                existingPlanJob.UpdateDate = now;
                existingPlanJob.UpdateDateUTC = utc;
                existingPlanJob.IsDelete = true;
                existingPlanJob.SetUpdate(_user, null);
            }
            _planJobRepository.UpdateRange(existingPlanJobs);
            await _planJobRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var PlanJobResponseDTOs = _mapper.Map<List<PlanJobCommandResponseDTO>>(existingPlanJobs);
            methodResult.Result = new DeletePlanJobCommandResponse(PlanJobResponseDTOs);
            return methodResult;
        }
    }
}
