using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using ProjectManager.CMD.Domain;
using Services.Common.Utilities;
using System.Linq;
using ProjectManager.CMD.Domain.IService;
using ProjectManager.Common;
using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateRequestRegistCommandHandler : RequestRegistCommandHandler, IRequestHandler<CreateRequestRegistCommand, MethodResult<CreateRequestRegistCommandResponse>>
    {
        private readonly IMediaService _mediaService;
        private readonly IFilesAttachmentRepository _filesAttachmentRepository;
        public CreateRequestRegistCommandHandler(IMapper mapper, IRequestRegistRepository RequestRegistRepository, IHttpContextAccessor httpContextAccessor, IFilesAttachmentRepository filesAttachmentRepository, IMediaService mediaService) : base(mapper, RequestRegistRepository, httpContextAccessor)
        {
            _filesAttachmentRepository = filesAttachmentRepository;
            _mediaService = mediaService;
        }

        /// <summary>
        /// Handle for creating a new RequestRegist
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateRequestRegistCommandResponse>> Handle(CreateRequestRegistCommand request, CancellationToken cancellationToken)
        {
            string tableName = QuanLyDuAnConstants.RequestRegist_TABLENAME;
            var methodResult = new MethodResult<CreateRequestRegistCommandResponse>();

            var parentRequestRegist = await _requestRegistRepository.SingleOrDefaultAsync(x => x.Id == request.ParentId && x.IsDelete == false).ConfigureAwait(false);
            var lastRequestRegistsRev = (await _requestRegistRepository.GetAllListAsync(x => x.ParentId == request.ParentId && x.IsDelete == false).ConfigureAwait(false)).Max(x => x.Rev);
            if (parentRequestRegist == null && (request.ParentId.HasValue && request.ParentId != 0))
            {
                methodResult.AddErrorMessage(nameof(ErrorCodeInsert.IErrN3), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.ParentId),request.ParentId)
                });
            }
            else if (!request.ParentId.HasValue || request.ParentId == 0)
            {
                request.ParentId =request.Rev= request.Level = 0;
                request.BarCode = (await _requestRegistRepository.IsGetTitleRequestRegistAsync((int)request.ProjectId, (int)request.WorkItemId, _user, (int)request.DocumentTypeId).ConfigureAwait(false));
                request.Code = request.BarCode.Replace("-", "");
            }
            else
            {
                request.ProjectId = (int)parentRequestRegist.ProjectId;
                request.WorkItemId = (int)parentRequestRegist.WorkItemId;
                request.DocumentTypeId = (int)parentRequestRegist.DocumentTypeId;
                request.Level = (parentRequestRegist.Level.HasValue ? ((int)parentRequestRegist.Level + 1) : 0);
                request.Rev = lastRequestRegistsRev.HasValue? lastRequestRegistsRev + 1:1;
                request.Code = !string.IsNullOrEmpty(parentRequestRegist.Code) ? parentRequestRegist.Code : "0";
                request.BarCode = !string.IsNullOrEmpty(parentRequestRegist.BarCode) ? parentRequestRegist.BarCode : "0";
            }
            var newRequestRegist = new RequestRegist(request.PlanRegisterId,
                                                        request.Code,
                                                        request.BarCode,
                                                        request.Title,
                                                        request.Descriptions,
                                                        request.Note,
                                                        (int)request.ParentId,
                                                        request.Level,
                                                        0,
                                                        (int)request.ProjectId,
                                                        (int)request.WorkItemId,
                                                        (int)request.DocumentTypeId,
                                                        request.Rev);
            newRequestRegist.SetCreate(_user);
            newRequestRegist.Status = request.Status.HasValue ? request.Status : 0;
            newRequestRegist.IsActive = request.IsActive.HasValue ? request.IsActive : true;
            newRequestRegist.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
            await _requestRegistRepository.AddAsync(newRequestRegist).ConfigureAwait(false);
            await _requestRegistRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);

            // tạo phiếu đánh giá sau khi update câu hỏi
            var isRequestRegist = await _requestRegistRepository.IsCreatedRequestRegistAsync((int)newRequestRegist.DocumentTypeId, (int)newRequestRegist.CreateBy, newRequestRegist.Id).ConfigureAwait(false);

            // ghi file vào server và lưu log file dữ liệu
            if(request.getFile() != null && request.getFile().Count>0)
            {
                foreach (var i in request.getFile())
                {
                    var result = await _mediaService.SaveFile(i, tableName, request.Code);
                    var newFilesAttachment = new FilesAttachment(newRequestRegist.Id,
                                                          tableName,
                                                          newRequestRegist.Code,
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
                    await _filesAttachmentRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
                }
            }
            else
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeInsert.IErr000), new[]
               {
                    ErrorHelpers.GetCommonErrorMessage(nameof(ErrorCodeInsert.IErr000))
                });
            }
            methodResult.Result = _mapper.Map<CreateRequestRegistCommandResponse>(newRequestRegist);
            return methodResult;
        }
    }
}