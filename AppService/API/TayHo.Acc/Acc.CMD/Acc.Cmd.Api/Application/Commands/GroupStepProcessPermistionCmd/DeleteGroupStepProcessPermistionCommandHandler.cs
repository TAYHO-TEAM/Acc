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
using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupStepProcessPermistionCommandHandler : GroupStepProcessPermistionCommandHandler, IRequestHandler<DeleteGroupStepProcessPermistionCommand, MethodResult<DeleteGroupStepProcessPermistionCommandResponse>>
    {
        public DeleteGroupStepProcessPermistionCommandHandler(IMapper mapper, IGroupStepProcessPermistionRepository GroupStepProcessPermistionRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupStepProcessPermistionRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing GroupStepProcessPermistion.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteGroupStepProcessPermistionCommandResponse>> Handle(DeleteGroupStepProcessPermistionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteGroupStepProcessPermistionCommandResponse>();
            var existingGroupStepProcessPermistions = await _GroupStepProcessPermistionRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupStepProcessPermistions == null || !existingGroupStepProcessPermistions.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingGroupStepProcessPermistion in existingGroupStepProcessPermistions)
            {
                existingGroupStepProcessPermistion.UpdateDate = now;
                existingGroupStepProcessPermistion.UpdateDateUTC = utc;
                existingGroupStepProcessPermistion.IsDelete = true;
                existingGroupStepProcessPermistion.SetUpdate(_user, null);
            }
            _GroupStepProcessPermistionRepository.UpdateRange(existingGroupStepProcessPermistions);
            await _GroupStepProcessPermistionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var GroupStepProcessPermistionResponseDTOs = _mapper.Map<List<GroupStepProcessPermistionCommandResponseDTO>>(existingGroupStepProcessPermistions);
            methodResult.Result = new DeleteGroupStepProcessPermistionCommandResponse(GroupStepProcessPermistionResponseDTOs);
            return methodResult;
        }
    }
}