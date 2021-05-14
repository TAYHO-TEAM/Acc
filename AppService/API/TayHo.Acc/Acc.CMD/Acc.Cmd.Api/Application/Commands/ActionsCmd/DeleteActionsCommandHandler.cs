using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
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
    public class DeleteActionsCommandHandler : ActionsCommandHandler, IRequestHandler<DeleteActionsCommand, MethodResult<DeleteActionsCommandResponse>>
    {
        public DeleteActionsCommandHandler(IMapper mapper, IActionsRepository ActionsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, ActionsRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Actions.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteActionsCommandResponse>> Handle(DeleteActionsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteActionsCommandResponse>();
            var existingActionss = await _actionsRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingActionss == null || !existingActionss.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingActions in existingActionss)
            {
                existingActions.UpdateDate = now;
                existingActions.UpdateDateUTC = utc;
                existingActions.IsDelete = true;
                existingActions.SetUpdate(_user, null);

            }
            _actionsRepository.UpdateRange(existingActionss);
            await _actionsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var ActionsResponseDTOs = _mapper.Map<List<ActionsCommandResponseDTO>>(existingActionss);
            methodResult.Result = new DeleteActionsCommandResponse(ActionsResponseDTOs);
            return methodResult;
        }
    }
}