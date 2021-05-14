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
    public class DeleteGroupStagesCommandHandler : GroupStagesCommandHandler, IRequestHandler<DeleteGroupStagesCommand, MethodResult<DeleteGroupStagesCommandResponse>>
    {
        public DeleteGroupStagesCommandHandler(IMapper mapper, IGroupStagesRepository GroupStagesRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, GroupStagesRepository,httpContextAccessor)
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
            var existingGroupStages = await _GroupStagesRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupStages == null || !existingGroupStages.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStage in existingGroupStages)
            {
                existingStage.UpdateDate = now;
                existingStage.UpdateDateUTC = utc;
                existingStage.IsDelete = true;
                existingStage.ModifyBy = 0;
                existingStage.SetUpdate(_user,0);
            }
            _GroupStagesRepository.UpdateRange(existingGroupStages);
            await _GroupStagesRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var GroupStagesResponseDTOs = _mapper.Map<List<GroupStagesCommandResponseDTO>>(existingGroupStages);
            methodResult.Result = new DeleteGroupStagesCommandResponse(GroupStagesResponseDTOs);
            return methodResult;
        }
    }
}