using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateGroupStagesCommandHandler : GroupStagesCommandHandler,IRequestHandler<UpdateGroupStagesCommand, MethodResult<UpdateGroupStagesCommandResponse>>
    {
        public UpdateGroupStagesCommandHandler(IMapper mapper, IGroupStagesRepository StagesRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, StagesRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing GroupStages.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateGroupStagesCommandResponse>> Handle(UpdateGroupStagesCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateGroupStagesCommandResponse>();
            var existingGroupStages = await _GroupStagesRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupStages == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingGroupStages.IsActive = request.IsActive.HasValue ? request.IsActive : existingGroupStages.IsActive;
            existingGroupStages.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingGroupStages.IsVisible;
            existingGroupStages.Status = request.Status.HasValue ? request.Status : existingGroupStages.Status;
            existingGroupStages.SetStagesId(request.StagesId);
            existingGroupStages.SetGroupId(request.GroupId);

            existingGroupStages.SetUpdate(_user,null);
            _GroupStagesRepository.Update(existingGroupStages);
            await _GroupStagesRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateGroupStagesCommandResponse>(existingGroupStages);
            return methodResult;
        }
    }
}