using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateReplyCommandHandler : ReplyCommandHandler, IRequestHandler<CreateReplyCommand, MethodResult<CreateReplyCommandResponse>>
    {
        public CreateReplyCommandHandler(IMapper mapper, IReplyRepository ReplyRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, ReplyRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new Reply
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateReplyCommandResponse>> Handle(CreateReplyCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateReplyCommandResponse>();
            var newReply = new Reply(request.RequestDetailId,
                                        request.Title,
                                        request.NoAttachment,
                                        request.Content);
            newReply.SetCreate(_user);
            newReply.Status = request.Status.HasValue ? request.Status : newReply.Status;
            newReply.IsActive = request.IsActive.HasValue ? request.IsActive : newReply.IsActive;
            newReply.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newReply.IsVisible;
            await _ReplyRepository.AddAsync(newReply).ConfigureAwait(false);
            await _ReplyRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateReplyCommandResponse>(newReply);
            return methodResult;
        }
    }
}