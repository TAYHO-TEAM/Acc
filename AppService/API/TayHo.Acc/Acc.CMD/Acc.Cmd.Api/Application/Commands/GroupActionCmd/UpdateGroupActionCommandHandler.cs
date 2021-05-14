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
    public class UpdateGroupActionCommandHandler : GroupActionCommandHandler,IRequestHandler<UpdateGroupActionCommand, MethodResult<UpdateGroupActionCommandResponse>>
    {
        public UpdateGroupActionCommandHandler(IMapper mapper, IGroupActionRepository ActionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, ActionRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing GroupAction.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateGroupActionCommandResponse>> Handle(UpdateGroupActionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateGroupActionCommandResponse>();
            var existingGroupAction = await _GroupActionRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupAction == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingGroupAction.IsActive = request.IsActive.HasValue ? request.IsActive : existingGroupAction.IsActive;
            existingGroupAction.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingGroupAction.IsVisible;
            existingGroupAction.Status = request.Status.HasValue ? request.Status : existingGroupAction.Status;
            existingGroupAction.SetActionId(request.ActionId);
            existingGroupAction.SetGroupId(request.GroupId);

            existingGroupAction.SetUpdate(_user,null);
            _GroupActionRepository.Update(existingGroupAction);
            await _GroupActionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateGroupActionCommandResponse>(existingGroupAction);
            return methodResult;
        }
    }
}