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
    public class DeleteGroupActionCommandHandler : GroupActionCommandHandler, IRequestHandler<DeleteGroupActionCommand, MethodResult<DeleteGroupActionCommandResponse>>
    {
        public DeleteGroupActionCommandHandler(IMapper mapper, IGroupActionRepository GroupActionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupActionRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing GroupAction.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteGroupActionCommandResponse>> Handle(DeleteGroupActionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteGroupActionCommandResponse>();
            var existingGroupActions = await _GroupActionRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupActions == null || !existingGroupActions.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingGroupAction in existingGroupActions)
            {
                existingGroupAction.UpdateDate = now;
                existingGroupAction.UpdateDateUTC = utc;
                existingGroupAction.IsDelete = true;
                existingGroupAction.SetUpdate(_user, null);
            }
            _GroupActionRepository.UpdateRange(existingGroupActions);
            await _GroupActionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var GroupActionResponseDTOs = _mapper.Map<List<GroupActionCommandResponseDTO>>(existingGroupActions);
            methodResult.Result = new DeleteGroupActionCommandResponse(GroupActionResponseDTOs);
            return methodResult;
        }
    }
}