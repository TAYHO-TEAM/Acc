using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteFilesAttachmentCommandHandler : FilesAttachmentCommandHandler, IRequestHandler<DeleteFilesAttachmentCommand, MethodResult<DeleteFilesAttachmentCommandResponse>>
    {
        public DeleteFilesAttachmentCommandHandler(IMapper mapper, IFilesAttachmentRepository FilesAttachmentRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, FilesAttachmentRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing FilesAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteFilesAttachmentCommandResponse>> Handle(DeleteFilesAttachmentCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteFilesAttachmentCommandResponse>();
            var existingFilesAttachments = await _FilesAttachmentRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingFilesAttachments == null || !existingFilesAttachments.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingFilesAttachment in existingFilesAttachments)
            {
                existingFilesAttachment.UpdateDate = now;
                existingFilesAttachment.UpdateDateUTC = utc;
                existingFilesAttachment.IsDelete = true;
                existingFilesAttachment.ModifyBy = 0;
                existingFilesAttachment.SetUpdate(0, 0);
            }
            _FilesAttachmentRepository.UpdateRange(existingFilesAttachments);
            await _FilesAttachmentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var FilesAttachmentResponseDTOs = _mapper.Map<List<FilesAttachmentCommandResponseDTO>>(existingFilesAttachments);
            methodResult.Result = new DeleteFilesAttachmentCommandResponse(FilesAttachmentResponseDTOs);
            return methodResult;
        }
    }
}