using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using ProjectManager.CMD.Domain.IService;
using ProjectManager.Common;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateResponseRegistCommandHandler : ResponseRegistCommandHandler, IRequestHandler<CreateResponseRegistCommand, MethodResult<CreateResponseRegistCommandResponse>>
    {
        private readonly IMediaService _mediaService;
        private readonly IFilesAttachmentRepository _filesAttachmentRepository;

        public CreateResponseRegistCommandHandler(IMapper mapper, IResponseRegistRepository ResponseRegistRepository,IHttpContextAccessor httpContextAccessor, IFilesAttachmentRepository filesAttachmentRepository, IMediaService mediaService) : base(mapper, ResponseRegistRepository,httpContextAccessor)
        {
            _filesAttachmentRepository = filesAttachmentRepository;
            _mediaService = mediaService;
        }

        /// <summary>
        /// Handle for creating a new ResponseRegist
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateResponseRegistCommandResponse>> Handle(CreateResponseRegistCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateResponseRegistCommandResponse>();
            var newResponseRegist = new ResponseRegist(request.Title,
                                                        request.Description,
                                                        request.StepProcessId,
                                                        request.RequestRegistId,
                                                        request.GroupId,
                                                        request.ReplyId,
                                                        request.NoAttachment,
                                                        request.IsApprove,
                                                        request.TypeOfResult);
            newResponseRegist.SetCreate(_user);
            newResponseRegist.Status = request.Status.HasValue ? request.Status : newResponseRegist.Status;
            newResponseRegist.IsActive = request.IsActive.HasValue ? request.IsActive : newResponseRegist.IsActive;
            newResponseRegist.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newResponseRegist.IsVisible;
            await _ResponseRegistRepository.AddAsync(newResponseRegist).ConfigureAwait(false);
            await _ResponseRegistRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            //await _mediaService.SaveFile(request.FormFiles, @"D:\duan\Content\Upload", "test"+ DateTime.Now.ToString("yyyyMMddHHmmss")+".png" , @"D:\duan\Content\Upload" + "\test" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
            //var newfileAttachment = new FilesAttachment((int)newResponseRegist.Id, QuanLyDuAnConstants.ResponseRegist_TABLENAME, "", "test", "png", "@@", "", "", @"D:\duan\Content\Upload");
            //await _filesAttachmentRepository.AddAsync(newfileAttachment);
            await _filesAttachmentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateResponseRegistCommandResponse>(newResponseRegist);
            return methodResult;
        }
    }
}