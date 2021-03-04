using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using ProjectManager.CMD.Domain.IService;
using Services.Common.Utilities;
using ProjectManager.CMD.Domain;
using ProjectManager.Common;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateDocumentReleasedCommandHandler : DocumentReleasedCommandHandler, IRequestHandler<CreateDocumentReleasedCommand, MethodResult<CreateDocumentReleasedCommandResponse>>
    {
        private readonly IMediaService _mediaService;
        private readonly IFilesAttachmentRepository _filesAttachmentRepository;
        public CreateDocumentReleasedCommandHandler(IMapper mapper, IDocumentReleasedRepository DocumentReleasedRepository,IHttpContextAccessor httpContextAccessor, IFilesAttachmentRepository filesAttachmentRepository, IMediaService mediaService) : base(mapper, DocumentReleasedRepository,httpContextAccessor)
        {
            _filesAttachmentRepository = filesAttachmentRepository;
            _mediaService = mediaService;
        }

        /// <summary>
        /// Handle for creating a new DocumentReleased
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateDocumentReleasedCommandResponse>> Handle(CreateDocumentReleasedCommand request, CancellationToken cancellationToken)
        {
            string tableName = QuanLyDuAnConstants.DocumentReleased_TABLENAME;
            var methodResult = new MethodResult<CreateDocumentReleasedCommandResponse>();
            request.Code = (await _documentReleasedRepository.IsGetTitleDocumentReleasedAsync(request.ProjectId?? 0, request.WorkItemId?? 0, request.DocumentTypeId ?? 0).ConfigureAwait(false));
            var newDocumentReleased = new DocumentReleased(request.Code,
                                                            request.Title,
                                                            request.Description,
                                                            request.DocumentTypeId,
                                                            request.ProjectId,
                                                            request.WorkItemId,
                                                            request.TagWorkItem,
                                                            request.Location,
                                                            request.Calendar,
                                                            request.NoAttachment);
            newDocumentReleased.SetCreate(_user);
            newDocumentReleased.Status = request.Status.HasValue ? request.Status : newDocumentReleased.Status;
            newDocumentReleased.IsActive = request.IsActive.HasValue ? request.IsActive : true;
            newDocumentReleased.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;

            await _documentReleasedRepository.AddAsync(newDocumentReleased).ConfigureAwait(false);
            await _documentReleasedRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            await _documentReleasedRepository.IsCreatedDocumentReleasedAsync((int)newDocumentReleased.DocumentTypeId, _user, newDocumentReleased.Id);
            // ghi file vào server và lưu log file dữ liệu
            if (request.getFile() != null && request.getFile().Count > 0)
            {
                foreach (var i in request.getFile())
                {
                    var result = await _mediaService.SaveFile(i, tableName, request.Code);
                    var newFilesAttachment = new FilesAttachment(newDocumentReleased.Id,
                                                          tableName,
                                                          newDocumentReleased.Code,
                                                          result.Item1,
                                                          result.Item5,
                                                          result.Item3,
                                                          result.Item2,
                                                          "",
                                                          result.Item4);
                    newFilesAttachment.SetCreate(_user);
                    newFilesAttachment.Status = request.Status.HasValue ? request.Status : newFilesAttachment.Status;
                    newFilesAttachment.IsActive = request.IsActive.HasValue ? request.IsActive : newFilesAttachment.IsActive;
                    newFilesAttachment.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newFilesAttachment.IsVisible;

                    await _filesAttachmentRepository.AddAsync(newFilesAttachment).ConfigureAwait(false);
                    await _filesAttachmentRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
                }
                await _documentReleasedRepository.DocumentReleasedProcessAsync();
            }
            else
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeInsert.IErr000), new[]
               {
                    ErrorHelpers.GetCommonErrorMessage(nameof(ErrorCodeInsert.IErr000))
                });
            }
            methodResult.Result = _mapper.Map<CreateDocumentReleasedCommandResponse>(newDocumentReleased);
            return methodResult;
        }
    }
}