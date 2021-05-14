using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupActionCommandHandler : GroupActionCommandHandler, IRequestHandler<CreateGroupActionCommand, MethodResult<CreateGroupActionCommandResponse>>
    {
        public CreateGroupActionCommandHandler(IMapper mapper, IGroupActionRepository GroupActionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupActionRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new GroupAction
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateGroupActionCommandResponse>> Handle(CreateGroupActionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateGroupActionCommandResponse>();
            var newGroupAction = new GroupAction(request.ActionId,
                                                    request.GroupId);
            newGroupAction.SetCreate(_user);
            newGroupAction.Status = request.Status.HasValue ? request.Status : newGroupAction.Status;
            newGroupAction.IsActive = request.IsActive.HasValue ? request.IsActive : newGroupAction.IsActive;
            newGroupAction.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newGroupAction.IsVisible;
            await _GroupActionRepository.AddAsync(newGroupAction).ConfigureAwait(false);
            await _GroupActionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateGroupActionCommandResponse>(newGroupAction);
            return methodResult;
        }
    }
}