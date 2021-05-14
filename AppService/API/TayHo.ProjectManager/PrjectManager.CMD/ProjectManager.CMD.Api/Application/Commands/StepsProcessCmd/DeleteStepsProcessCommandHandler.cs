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
    public class DeleteStepsProcessCommandHandler : StepsProcessCommandHandler, IRequestHandler<DeleteStepsProcessCommand, MethodResult<DeleteStepsProcessCommandResponse>>
    {
        public DeleteStepsProcessCommandHandler(IMapper mapper, IStepsProcessRepository StepsProcessRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, StepsProcessRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing StepsProcess.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteStepsProcessCommandResponse>> Handle(DeleteStepsProcessCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteStepsProcessCommandResponse>();
            var existingStepsProcesss = await _StepsProcessRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingStepsProcesss == null || !existingStepsProcesss.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStepsProcess in existingStepsProcesss)
            {
                existingStepsProcess.UpdateDate = now;
                existingStepsProcess.UpdateDateUTC = utc;
                existingStepsProcess.IsDelete = true;
                existingStepsProcess.SetUpdate(_user, null);
            }
            _StepsProcessRepository.UpdateRange(existingStepsProcesss);
            await _StepsProcessRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var StepsProcessResponseDTOs = _mapper.Map<List<StepsProcessCommandResponseDTO>>(existingStepsProcesss);
            methodResult.Result = new DeleteStepsProcessCommandResponse(StepsProcessResponseDTOs);
            return methodResult;
        }
    }
}