using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateRequestsCommandHandler : RequestsCommandHandler, IRequestHandler<CreateRequestsCommand, MethodResult<CreateRequestsCommandResponse>>
    {
        public CreateRequestsCommandHandler(IMapper mapper, IRequestsRepository RequestsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, RequestsRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new Requests
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateRequestsCommandResponse>> Handle(CreateRequestsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateRequestsCommandResponse>();
            var newRequests = new Requests( request.Code,
                                            request.ProjectId,
                                            request.RequestFromId,
                                            request.StageId,
                                            request.Priority,
                                            request.ReplyById,
                                            request.SendDateTime,
                                            request.NoAttachment);
            newRequests.SetCreate(_user);
            newRequests.Status = request.Status.HasValue ? request.Status : newRequests.Status;
            newRequests.IsActive = request.IsActive.HasValue ? request.IsActive : newRequests.IsActive;
            newRequests.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newRequests.IsVisible;
            await _RequestsRepository.AddAsync(newRequests).ConfigureAwait(false);
            await _RequestsRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateRequestsCommandResponse>(newRequests);
            return methodResult;
        }
    }
}