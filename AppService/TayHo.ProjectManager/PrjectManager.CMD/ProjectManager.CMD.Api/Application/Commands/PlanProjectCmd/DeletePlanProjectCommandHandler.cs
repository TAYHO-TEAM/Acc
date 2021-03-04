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
    public class DeletePlanProjectCommandHandler : PlanProjectCommandHandler, IRequestHandler<DeletePlanProjectCommand, MethodResult<DeletePlanProjectCommandResponse>>
    {
        public DeletePlanProjectCommandHandler(IMapper mapper, IPlanProjectRepository PlanProjectRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, PlanProjectRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing PlanProject.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeletePlanProjectCommandResponse>> Handle(DeletePlanProjectCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeletePlanProjectCommandResponse>();
            var existingPlanProjects = await _planProjectRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanProjects == null || !existingPlanProjects.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingPlanProject in existingPlanProjects)
            {
                existingPlanProject.UpdateDate = now;
                existingPlanProject.UpdateDateUTC = utc;
                existingPlanProject.IsDelete = true;
                existingPlanProject.SetUpdate(_user, null);
            }
            _planProjectRepository.UpdateRange(existingPlanProjects);
            await _planProjectRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var PlanProjectResponseDTOs = _mapper.Map<List<PlanProjectCommandResponseDTO>>(existingPlanProjects);
            methodResult.Result = new DeletePlanProjectCommandResponse(PlanProjectResponseDTOs);
            return methodResult;
        }
    }
}
