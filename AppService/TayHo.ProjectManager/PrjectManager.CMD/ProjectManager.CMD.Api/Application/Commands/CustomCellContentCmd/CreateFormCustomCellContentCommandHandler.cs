using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using ProjectManager.Common;
using ProjectManager.CMD.Domain.IService;
using ProjectManager.CMD.Domain;
using Services.Common.Utilities;
using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateFormCustomCellContentCommandHandler : CustomCellContentCommandHandler, IRequestHandler<CreateFormCustomCellContentCommand, MethodResult<CreateFormCustomCellContentCommandResponse>>
    {
        private readonly IMediaService _mediaService;
        private readonly IFilesAttachmentRepository _filesAttachmentRepository;
        public CreateFormCustomCellContentCommandHandler(IMapper mapper, ICustomCellContentRepository CustomCellContentRepository, IHttpContextAccessor httpContextAccessor, IFilesAttachmentRepository filesAttachmentRepository, IMediaService mediaService) : base(mapper, CustomCellContentRepository, httpContextAccessor)
        {
            _filesAttachmentRepository = filesAttachmentRepository;
            _mediaService = mediaService;
        }

        /// <summary>
        /// Handle for creating a new FormCustomCellContent
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateFormCustomCellContentCommandResponse>> Handle(CreateFormCustomCellContentCommand request, CancellationToken cancellationToken)
        {
            string tableName = QuanLyDuAnConstants.CustomCellContent_TABLENAME;
            var methodResult = new MethodResult<CreateFormCustomCellContentCommandResponse>();
            var existingCustomCellContent = await _customCellContentRepository.FirstOrDefaultAsync(x => x.CustomFormContentId == (request.CustomFormContentId ?? 0)
                                                                                                        && x.CustomFormBodyId == (request.CustomFormBodyId ?? 0)
                                                                                                        && x.CustomColumId == (request.CustomColumId ?? 0)
                                                                                                        && x.NoRown == (request.NoRown ?? 0)
                                                                                                        && (x.IsDelete == false || x.IsDelete == null)).ConfigureAwait(false);
            //x.CustomFormContentId == (request.CustomFormContentId ?? 0)
            //&& x.CustomFormBodyId == (request.CustomFormBodyId ?? 0)
            //&& x.CustomColumId == (request.CustomColumId ?? 0)
            //&& x.NoRown == (request.NoRown ?? 0)
            //&& (x.IsDelete == false || x.IsDelete == null)

            var newCustomCellContent = new CustomCellContent(request.CustomFormContentId,
                                                                request.CustomFormBodyId,
                                                                request.CustomColumId,
                                                                request.Contents,
                                                                request.NoRown);
            newCustomCellContent.SetCreate(_user);
            newCustomCellContent.Status = request.Status.HasValue ? request.Status : 0;
            newCustomCellContent.IsActive = request.IsActive.HasValue ? request.IsActive : true;
            newCustomCellContent.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;

            if (existingCustomCellContent != null)
            {
                existingCustomCellContent.SetContents(request.Contents);
                existingCustomCellContent.SetUpdate(_user, 0);
                _customCellContentRepository.Update(existingCustomCellContent);
            }
            else
            {
                await _customCellContentRepository.AddAsync(newCustomCellContent).ConfigureAwait(false);
            }

            await _customCellContentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ghi file vào server và lưu log file dữ liệu
            int OwnerById = (existingCustomCellContent == null ? newCustomCellContent.Id : existingCustomCellContent.Id);
            try
            {
                if (request.getFile() != null && request.getFile().Count > 0)
                {
                    var i = request.getFile()[0];
                    //foreach (var i in request.getFile())
                    //{
                    var result = await _mediaService.SaveFile(i, tableName, i.FileName);
                    //FilesAttachment newFilesAttachment = new FilesAttachment(1,
                    //                                     "abc",
                    //                                     "abc",
                    //                                     "abc",
                    //                                     "abc",
                    //                                     "abc",
                    //                                     "abc",
                    //                                    "abc",
                    //                                     "abc");
                    var newFilesAttachment = new FilesAttachment(OwnerById,
                                                          tableName,
                                                          i.FileName,
                                                          result.Item1,
                                                          result.Item5,
                                                          result.Item3,
                                                          result.Item2,
                                                          "",
                                                          result.Item4);
                    newFilesAttachment.SetCreate(_user);
                    newFilesAttachment.Status = request.Status.HasValue ? request.Status : newFilesAttachment.Status;
                    newFilesAttachment.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                    newFilesAttachment.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;

                    await _filesAttachmentRepository.AddAsync(newFilesAttachment).ConfigureAwait(false);
                    await _filesAttachmentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    if (existingCustomCellContent == null)
                    {
                        newCustomCellContent.SetContents((newFilesAttachment.Host + newFilesAttachment.Url + "/" + newFilesAttachment.FileName).Replace('\\','/'));
                       
                    }
                    else
                    {
                        existingCustomCellContent.SetContents((newFilesAttachment.Host + newFilesAttachment.Url + "/" + newFilesAttachment.FileName).Replace('\\', '/'));
                        existingCustomCellContent.SetUpdate(_user, 0);
                    }

                    _customCellContentRepository.Update(existingCustomCellContent == null ? newCustomCellContent : existingCustomCellContent);
                    await _customCellContentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    //}
                }

            }
            catch (Exception ex)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeInsert.IErr000), new[]
                 {
                    ErrorHelpers.GenerateErrorResult(nameof(ErrorCodeInsert.IErr000),ErrorCodeInsert.IErr000)
                });

            }
            methodResult.Result = _mapper.Map<CreateFormCustomCellContentCommandResponse>(existingCustomCellContent == null? newCustomCellContent: existingCustomCellContent);
            return methodResult;
        }
    }
}