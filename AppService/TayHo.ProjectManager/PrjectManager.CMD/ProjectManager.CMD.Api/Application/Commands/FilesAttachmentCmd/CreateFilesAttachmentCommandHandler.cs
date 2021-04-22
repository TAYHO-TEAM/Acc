using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using ProjectManager.CMD.Domain.IService;
using ProjectManager.CMD.Domain;
using Services.Common.Utilities;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateFilesAttachmentCommandHandler : FilesAttachmentCommandHandler, IRequestHandler<CreateFilesAttachmentCommand, MethodResult<CreateFilesAttachmentCommandResponse>>
    {
        private readonly IMediaService _mediaService;
        public CreateFilesAttachmentCommandHandler(IMapper mapper, IFilesAttachmentRepository FilesAttachmentRepository, IHttpContextAccessor httpContextAccessor, IMediaService mediaService) : base(mapper, FilesAttachmentRepository, httpContextAccessor)
        {
            _mediaService = mediaService;
        }

        /// <summary>
        /// Handle for creating a new FilesAttachment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateFilesAttachmentCommandResponse>> Handle(CreateFilesAttachmentCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateFilesAttachmentCommandResponse>();
            if (request.getFile() != null)
            {
                var result = await _mediaService.SaveFile(request.getFile(), request.OwnerByTable, request.Code);
                var newFilesAttachment = new FilesAttachment(request.OwnerById,
                                                            request.OwnerByTable,
                                                            request.Code,
                                                            result.Item1,
                                                            result.Item6,
                                                            result.Item5,
                                                            result.Item3,
                                                            result.Item2,
                                                            request.Type,
                                                            result.Item4);
                newFilesAttachment.SetCreate(_user);
                newFilesAttachment.Status = request.Status.HasValue ? request.Status : newFilesAttachment.Status;
                newFilesAttachment.IsActive = request.IsActive.HasValue ? request.IsActive : newFilesAttachment.IsActive;
                newFilesAttachment.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newFilesAttachment.IsVisible;

                await _FilesAttachmentRepository.AddAsync(newFilesAttachment).ConfigureAwait(false);
                await _FilesAttachmentRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
                methodResult.Result = _mapper.Map<CreateFilesAttachmentCommandResponse>(newFilesAttachment);
            }
            else
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeInsert.IErr000), new[]
               {
                    ErrorHelpers.GetCommonErrorMessage(nameof(ErrorCodeInsert.IErr000))
                });
            }
            return methodResult;
        }
    }
}