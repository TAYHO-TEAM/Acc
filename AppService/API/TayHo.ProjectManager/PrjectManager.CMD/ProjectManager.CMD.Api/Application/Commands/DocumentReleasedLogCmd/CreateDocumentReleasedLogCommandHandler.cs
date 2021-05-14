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
    public class CreateDocumentReleasedLogCommandHandler : DocumentReleasedLogCommandHandler, IRequestHandler<CreateDocumentReleasedLogCommand, MethodResult<CreateDocumentReleasedLogCommandResponse>>
    {
        public CreateDocumentReleasedLogCommandHandler(IMapper mapper, IDocumentReleasedLogRepository DocumentReleasedLogRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, DocumentReleasedLogRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new DocumentReleasedLog
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateDocumentReleasedLogCommandResponse>> Handle(CreateDocumentReleasedLogCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateDocumentReleasedLogCommandResponse>();
            var newDocumentReleasedLog = new DocumentReleasedLog(request.AccountId,
                                                                request.DocumentReleasedId,
                                                                request.Note);
            newDocumentReleasedLog.SetCreate(_user);
            newDocumentReleasedLog.Status = request.Status.HasValue ? request.Status : newDocumentReleasedLog.Status;
            newDocumentReleasedLog.IsActive = request.IsActive.HasValue ? request.IsActive : newDocumentReleasedLog.IsActive;
            newDocumentReleasedLog.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newDocumentReleasedLog.IsVisible;
            await _DocumentReleasedLogRepository.AddAsync(newDocumentReleasedLog).ConfigureAwait(false);
            await _DocumentReleasedLogRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateDocumentReleasedLogCommandResponse>(newDocumentReleasedLog);
            return methodResult;
        }
    }
}