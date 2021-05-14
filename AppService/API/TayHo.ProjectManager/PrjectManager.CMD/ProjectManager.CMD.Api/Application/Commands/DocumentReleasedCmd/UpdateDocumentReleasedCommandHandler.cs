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
    public class UpdateDocumentReleasedCommandHandler : DocumentReleasedCommandHandler,IRequestHandler<UpdateDocumentReleasedCommand, MethodResult<UpdateDocumentReleasedCommandResponse>>
    {
        public UpdateDocumentReleasedCommandHandler(IMapper mapper, IDocumentReleasedRepository DocumentReleasedRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, DocumentReleasedRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing DocumentReleased.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateDocumentReleasedCommandResponse>> Handle(UpdateDocumentReleasedCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateDocumentReleasedCommandResponse>();
            var existingDocumentReleased = await _documentReleasedRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingDocumentReleased == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingDocumentReleased.IsActive = request.IsActive.HasValue ? request.IsActive : existingDocumentReleased.IsActive;
            existingDocumentReleased.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingDocumentReleased.IsVisible;
            existingDocumentReleased.Status = request.Status.HasValue ? request.Status : existingDocumentReleased.Status;
            existingDocumentReleased.SetTitle(request.Title);
            existingDocumentReleased.SetDescription(request.Description);
            existingDocumentReleased.SetDocumentTypeId(request.DocumentTypeId);
            existingDocumentReleased.SetProjectId(request.ProjectId);
            existingDocumentReleased.SetWorkItemId(request.WorkItemId);
            existingDocumentReleased.SetTagWorkItem(request.TagWorkItem);
            existingDocumentReleased.SetLocation(request.Location);
            existingDocumentReleased.SetCalendar(request.Calendar);
            existingDocumentReleased.SetNoAttachment(request.NoAttachment);

            existingDocumentReleased.SetUpdate(_user,0);
            _documentReleasedRepository.Update(existingDocumentReleased);
            await _documentReleasedRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateDocumentReleasedCommandResponse>(existingDocumentReleased);
            return methodResult;
        }
    }
}