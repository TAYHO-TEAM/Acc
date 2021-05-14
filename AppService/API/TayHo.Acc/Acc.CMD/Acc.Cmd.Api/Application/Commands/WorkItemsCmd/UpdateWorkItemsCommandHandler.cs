using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateWorkItemsCommandHandler : WorkItemsCommandHandler,IRequestHandler<UpdateWorkItemsCommand, MethodResult<UpdateWorkItemsCommandResponse>>
    {
        public UpdateWorkItemsCommandHandler(IMapper mapper, IWorkItemsRepository workItemsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, workItemsRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing WorkItems.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateWorkItemsCommandResponse>> Handle(UpdateWorkItemsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateWorkItemsCommandResponse>();
            var existingWorkItems = await _workItemsRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingWorkItems == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingWorkItems.IsActive = request.IsActive.HasValue ? request.IsActive : existingWorkItems.IsActive;
            existingWorkItems.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingWorkItems.IsVisible;
            existingWorkItems.Status = request.Status.HasValue ? request.Status : existingWorkItems.Status;

            existingWorkItems.SetCode(request.Code);
            existingWorkItems.SetBarCode(request.BarCode);
            existingWorkItems.SetTitle(request.Title);
            existingWorkItems.SetDescription(request.Description);
            existingWorkItems.SetParentId(request.ParentId);
            existingWorkItems.Setlevel(request.level);
            existingWorkItems.SetProjectId(request.ProjectId);

            existingWorkItems.SetUpdate(_user,null);
            _workItemsRepository.Update(existingWorkItems);
            await _workItemsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateWorkItemsCommandResponse>(existingWorkItems);
            return methodResult;
        }
    }
}