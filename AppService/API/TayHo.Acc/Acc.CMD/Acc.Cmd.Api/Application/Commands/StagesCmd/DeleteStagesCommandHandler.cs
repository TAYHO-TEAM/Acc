using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
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

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteStagesCommandHandler : StagesCommandHandler, IRequestHandler<DeleteStagesCommand, MethodResult<DeleteStagesCommandResponse>>
    {
        public DeleteStagesCommandHandler(IMapper mapper, IStagesRepository StagesRepository) : base(mapper, StagesRepository)
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
            var existingStagess = await _StagesRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingStagess == null || !existingStagess.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStages in existingStagess)
            {
                existingStages.UpdateDate = now;
                existingStages.UpdateDateUTC = utc;
                existingStages.IsDelete = true;
                _StagesRepository.Update(existingStages);
            }

            await _StagesRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var StagesResponseDTOs = _mapper.Map<List<StagesCommandResponseDTO>>(existingStagess);
            methodResult.Result = new DeleteStagesCommandResponse(StagesResponseDTOs);
            return methodResult;
        }
    }
}