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

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupStagesCommandHandler : GroupStagesCommandHandler, IRequestHandler<DeleteGroupStagesCommand, MethodResult<DeleteGroupStagesCommandResponse>>
    {
        public DeleteGroupStagesCommandHandler(IMapper mapper, IGroupStagesRepository GroupStagesRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupStagesRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing GroupStages.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteGroupStagesCommandResponse>> Handle(DeleteGroupStagesCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteGroupStagesCommandResponse>();
            var existingGroupStagess = await _GroupStagesRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupStagess == null || !existingGroupStagess.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingGroupStages in existingGroupStagess)
            {
                existingGroupStages.UpdateDate = now;
                existingGroupStages.UpdateDateUTC = utc;
                existingGroupStages.IsDelete = true;
                existingGroupStages.SetUpdate(_user, null);
            }
            _GroupStagesRepository.UpdateRange(existingGroupStagess);
            await _GroupStagesRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var GroupStagesResponseDTOs = _mapper.Map<List<GroupStagesCommandResponseDTO>>(existingGroupStagess);
            methodResult.Result = new DeleteGroupStagesCommandResponse(GroupStagesResponseDTOs);
            return methodResult;
        }
    }
}