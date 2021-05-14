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
    public class CreateWorkItemsCommandHandler : WorkItemsCommandHandler, IRequestHandler<CreateWorkItemsCommand, MethodResult<CreateWorkItemsCommandResponse>>
    {
        public CreateWorkItemsCommandHandler(IMapper mapper, IWorkItemsRepository WorkItemsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, WorkItemsRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new WorkItems
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateWorkItemsCommandResponse>> Handle(CreateWorkItemsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateWorkItemsCommandResponse>();

            var newWorkItems = new WorkItems(request.Code,
                                                request.BarCode,
                                                request.Title,
                                                request.Description,
                                                request.ParentId,
                                                request.level,
                                                request.ProjectId);

            newWorkItems.SetCreate(_user);
            newWorkItems.Status = request.Status.HasValue ? request.Status : newWorkItems.Status;
            newWorkItems.IsActive = request.IsActive.HasValue ? request.IsActive : newWorkItems.IsActive;
            newWorkItems.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newWorkItems.IsVisible;
            await _workItemsRepository.AddAsync(newWorkItems).ConfigureAwait(false);
            await _workItemsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateWorkItemsCommandResponse>(newWorkItems);
            return methodResult;
        }
    }
}