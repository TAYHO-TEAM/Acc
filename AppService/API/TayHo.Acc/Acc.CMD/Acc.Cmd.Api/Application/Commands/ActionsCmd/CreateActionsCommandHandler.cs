using Acc.Cmd.Domain;
using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.Security;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;
using Services.Common.DomainObjects.Exceptions;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateActionsCommandHandler : ActionsCommandHandler, IRequestHandler<CreateActionsCommand, MethodResult<CreateActionsCommandResponse>>
    {
        public CreateActionsCommandHandler(IMapper mapper, IActionsRepository ActionsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, ActionsRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new Actions
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateActionsCommandResponse>> Handle(CreateActionsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateActionsCommandResponse>();
            if(request.ParentId > 0)
            {
                var parentAction = await _actionsRepository.SingleOrDefaultAsync(x => x.Id == request.ParentId && x.IsDelete == false).ConfigureAwait(false);
                if (parentAction == null)
                {
                    methodResult.AddErrorMessage(nameof(ErrorCodeInsert.IErrN3), new[]
                    {
                    ErrorHelpers.GenerateErrorResult(nameof(request.ParentId),request.ParentId)
                });
                }
                else
                {
                    request.Level = (parentAction.Level.HasValue ? ((int)parentAction.Level + 1) : 0);
                }
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            var newActions = new Actions(request.ParentId,
                                        request.Title,
                                        request.Descriptions,
                                        request.Icon,
                                        request.Url,
                                        request.CategoryId,
                                        request.Level,
                                        request.Priority);
            newActions.SetCreate(_user);
            newActions.Status = request.Status.HasValue ? request.Status : newActions.Status;
            newActions.IsActive = request.IsActive.HasValue ? request.IsActive : newActions.IsActive;
            newActions.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newActions.IsVisible;
            await _actionsRepository.AddAsync(newActions).ConfigureAwait(false);
            await _actionsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateActionsCommandResponse>(newActions);
            return methodResult;
        }
    }
}