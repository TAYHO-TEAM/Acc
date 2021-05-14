using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateDocumentReleasedLogCommandHandler : DocumentReleasedLogCommandHandler,IRequestHandler<UpdateDocumentReleasedLogCommand, MethodResult<UpdateDocumentReleasedLogCommandResponse>>
    {
        public UpdateDocumentReleasedLogCommandHandler(IMapper mapper, IDocumentReleasedLogRepository DocumentReleasedLogRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, DocumentReleasedLogRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing DocumentReleasedLog.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateDocumentReleasedLogCommandResponse>> Handle(UpdateDocumentReleasedLogCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateDocumentReleasedLogCommandResponse>();
            var existingDocumentReleasedLog = await _DocumentReleasedLogRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingDocumentReleasedLog == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingDocumentReleasedLog.IsActive = request.IsActive.HasValue ? request.IsActive : existingDocumentReleasedLog.IsActive;
            existingDocumentReleasedLog.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingDocumentReleasedLog.IsVisible;
            existingDocumentReleasedLog.Status = request.Status.HasValue ? (request.Status >2 ? request.Status :3 ): 3;
            existingDocumentReleasedLog.SetAccountId(request.AccountId);
            existingDocumentReleasedLog.SetDocumentReleasedId(request.DocumentReleasedId);
            existingDocumentReleasedLog.SetNote(request.Note);

            existingDocumentReleasedLog.SetUpdate(_user,0);
            _DocumentReleasedLogRepository.Update(existingDocumentReleasedLog);
            await _DocumentReleasedLogRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateDocumentReleasedLogCommandResponse>(existingDocumentReleasedLog);
            return methodResult;
        }
    }
}