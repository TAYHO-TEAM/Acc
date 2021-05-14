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
    public class UpdateFilesAttachmentCommandHandler : FilesAttachmentCommandHandler,IRequestHandler<UpdateFilesAttachmentCommand, MethodResult<UpdateFilesAttachmentCommandResponse>>
    {
        public UpdateFilesAttachmentCommandHandler(IMapper mapper, IFilesAttachmentRepository FilesAttachmentRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, FilesAttachmentRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing FilesAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateFilesAttachmentCommandResponse>> Handle(UpdateFilesAttachmentCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateFilesAttachmentCommandResponse>();
            var existingFilesAttachment = await _FilesAttachmentRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingFilesAttachment == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingFilesAttachment.IsActive = request.IsActive.HasValue ? request.IsActive : existingFilesAttachment.IsActive;
            existingFilesAttachment.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingFilesAttachment.IsVisible;
            existingFilesAttachment.Status = request.Status.HasValue ? request.Status : existingFilesAttachment.Status;
            existingFilesAttachment.SetOwnerById(request.OwnerById);
            existingFilesAttachment.SetOwnerByTable(request.OwnerByTable);
            existingFilesAttachment.SetCode(request.Code);
            existingFilesAttachment.SetFileName(request.FileName);
            existingFilesAttachment.SetTail(request.Tail);
            existingFilesAttachment.SetUrl(request.Url);
            existingFilesAttachment.SetHost(request.Host);
            existingFilesAttachment.SetType(request.Type);
            existingFilesAttachment.SetDirect(request.Direct);
            existingFilesAttachment.SetUpdate(_user,0);
            _FilesAttachmentRepository.Update(existingFilesAttachment);
            await _FilesAttachmentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateFilesAttachmentCommandResponse>(existingFilesAttachment);
            return methodResult;
        }
    }
}