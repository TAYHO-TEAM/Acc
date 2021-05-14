using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeletePlanRegisterCommandHandler : PlanRegisterCommandHandler, IRequestHandler<DeletePlanRegisterCommand, MethodResult<DeletePlanRegisterCommandResponse>>
    {
        public DeletePlanRegisterCommandHandler(IMapper mapper, IPlanRegisterRepository PlanRegisterRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, PlanRegisterRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing PlanRegister.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeletePlanRegisterCommandResponse>> Handle(DeletePlanRegisterCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeletePlanRegisterCommandResponse>();
            var existingPlanRegister = await _planRegisterRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanRegister == null || !existingPlanRegister.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStage in existingPlanRegister)
            {
                existingStage.UpdateDate = now;
                existingStage.UpdateDateUTC = utc;
                existingStage.IsDelete = true;
                existingStage.ModifyBy = 0;
                existingStage.SetUpdate(_user,0);
            }
            _planRegisterRepository.UpdateRange(existingPlanRegister);
            await _planRegisterRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var PlanRegisterResponseDTOs = _mapper.Map<List<PlanRegisterCommandResponseDTO>>(existingPlanRegister);
            methodResult.Result = new DeletePlanRegisterCommandResponse(PlanRegisterResponseDTOs);
            return methodResult;
        }
    }
}