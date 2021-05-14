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
    public class UpdateReplyCommandHandler : ReplyCommandHandler,IRequestHandler<UpdateReplyCommand, MethodResult<UpdateReplyCommandResponse>>
    {
        public UpdateReplyCommandHandler(IMapper mapper, IReplyRepository ReplyRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, ReplyRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing Reply.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateReplyCommandResponse>> Handle(UpdateReplyCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateReplyCommandResponse>();
            var existingReply = await _ReplyRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingReply == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingReply.IsActive = request.IsActive.HasValue ? request.IsActive : existingReply.IsActive;
            existingReply.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingReply.IsVisible;
            existingReply.Status = request.Status.HasValue ? request.Status : existingReply.Status;
            existingReply.SetRequestDetailId(request.RequestDetailId);
            existingReply.SetTitle(request.Title);
            existingReply.SetNoAttachment(request.NoAttachment);
            existingReply.SetContent(request.Content);
            existingReply.SetUpdate(_user,0);
            _ReplyRepository.Update(existingReply);
            await _ReplyRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateReplyCommandResponse>(existingReply);
            return methodResult;
        }
    }
}