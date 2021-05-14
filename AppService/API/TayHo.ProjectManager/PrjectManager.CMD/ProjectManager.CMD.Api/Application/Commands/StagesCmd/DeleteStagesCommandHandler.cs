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
    public class DeleteStagesCommandHandler : StagesCommandHandler, IRequestHandler<DeleteStagesCommand, MethodResult<DeleteStagesCommandResponse>>
    {
        public DeleteStagesCommandHandler(IMapper mapper, IStagesRepository StagesRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, StagesRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Stages.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteStagesCommandResponse>> Handle(DeleteStagesCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteStagesCommandResponse>();
            var existingStages = await _StagesRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingStages == null || !existingStages.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStage in existingStages)
            {
                existingStage.UpdateDate = now;
                existingStage.UpdateDateUTC = utc;
                existingStage.IsDelete = true;
                existingStage.ModifyBy = 0;
                existingStage.SetUpdate(_user,0);
                
            }
            _StagesRepository.UpdateRange(existingStages);
            await _StagesRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var StagesResponseDTOs = _mapper.Map<List<StagesCommandResponseDTO>>(existingStages);
            methodResult.Result = new DeleteStagesCommandResponse(StagesResponseDTOs);
            return methodResult;
        }
    }
}