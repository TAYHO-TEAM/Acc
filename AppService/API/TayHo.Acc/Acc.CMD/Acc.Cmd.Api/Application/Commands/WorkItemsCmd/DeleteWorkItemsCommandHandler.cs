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
    public class DeleteWorkItemsCommandHandler : WorkItemsCommandHandler, IRequestHandler<DeleteWorkItemsCommand, MethodResult<DeleteWorkItemsCommandResponse>>
    {
        public DeleteWorkItemsCommandHandler(IMapper mapper, IWorkItemsRepository WorkItemsRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, WorkItemsRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing WorkItems.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteWorkItemsCommandResponse>> Handle(DeleteWorkItemsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteWorkItemsCommandResponse>();
            var existingWorkItemss = await _workItemsRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingWorkItemss == null || !existingWorkItemss.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingWorkItems in existingWorkItemss)
            {
                existingWorkItems.UpdateDate = now;
                existingWorkItems.UpdateDateUTC = utc;
                existingWorkItems.IsDelete = true;
                existingWorkItems.SetUpdate(_user, null);
            }
            _workItemsRepository.UpdateRange(existingWorkItemss);
            await _workItemsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var WorkItemsResponseDTOs = _mapper.Map<List<WorkItemsCommandResponseDTO>>(existingWorkItemss);
            methodResult.Result = new DeleteWorkItemsCommandResponse(WorkItemsResponseDTOs);
            return methodResult;
        }
    }
}