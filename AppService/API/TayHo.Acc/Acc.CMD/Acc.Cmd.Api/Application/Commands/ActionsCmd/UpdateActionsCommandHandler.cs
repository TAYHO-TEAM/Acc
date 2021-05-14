using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateActionsCommandHandler : ActionsCommandHandler,IRequestHandler<UpdateActionsCommand, MethodResult<UpdateActionsCommandResponse>>
    {
        public UpdateActionsCommandHandler(IMapper mapper, IActionsRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing Actions.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateActionsCommandResponse>> Handle(UpdateActionsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateActionsCommandResponse>();
            var existingActions = await _actionsRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingActions == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            var parentActions = await _actionsRepository.SingleOrDefaultAsync(x => x.Id == existingActions.ParentId && x.IsDelete == false).ConfigureAwait(false);
            if (parentActions == null)
            {
              
            }

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingActions.IsActive = request.IsActive.HasValue ? request.IsActive : existingActions.IsActive;
            existingActions.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingActions.IsVisible;
            existingActions.Status = request.Status.HasValue ? request.Status : existingActions.Status;
            existingActions.SetParentId(parentActions== null? 0:parentActions.Id );
            existingActions.SetTitle(request.Title);
            existingActions.SetDescriptions(request.Descriptions);
            existingActions.SetIcon(request.Icon);
            existingActions.SetUrl(request.Url);
            existingActions.SetCategoryId(request.CategoryId);
            existingActions.SetLevel((parentActions != null && parentActions.Level.HasValue )? parentActions.Level +1 : 0);
            existingActions.SetPriority(request.Priority);
            existingActions.SetUpdate(_user,null);
            _actionsRepository.Update(existingActions);
            await _actionsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateActionsCommandResponse>(existingActions);
            return methodResult;
        }
    }
}