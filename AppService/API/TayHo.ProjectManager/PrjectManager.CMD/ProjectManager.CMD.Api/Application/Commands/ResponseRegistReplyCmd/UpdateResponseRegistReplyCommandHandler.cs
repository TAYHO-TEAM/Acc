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
    public class UpdateResponseRegistReplyCommandHandler : ResponseRegistReplyCommandHandler,IRequestHandler<UpdateResponseRegistReplyCommand, MethodResult<UpdateResponseRegistReplyCommandResponse>>
    {
        public UpdateResponseRegistReplyCommandHandler(IMapper mapper, IResponseRegistReplyRepository ResponseRegistReplyRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, ResponseRegistReplyRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing ResponseRegistReply.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateResponseRegistReplyCommandResponse>> Handle(UpdateResponseRegistReplyCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateResponseRegistReplyCommandResponse>();
            var existingResponseRegistReply = await _ResponseRegistReplyRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false && x.ReplyAccountId == _user).ConfigureAwait(false);
            if (existingResponseRegistReply == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingResponseRegistReply.IsActive = request.IsActive.HasValue ? request.IsActive : existingResponseRegistReply.IsActive;
            existingResponseRegistReply.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingResponseRegistReply.IsVisible;
            existingResponseRegistReply.Status = request.Status.HasValue ? request.Status : existingResponseRegistReply.Status;

            existingResponseRegistReply.SetTitle(request.Title);
            existingResponseRegistReply.SetDescription(request.Description);
            existingResponseRegistReply.SetReplyAccountId(request.ReplyAccountId);
            existingResponseRegistReply.SetResponseRegitId(request.ResponseRegitId);
            existingResponseRegistReply.SetNoAttachment(request.NoAttachment);

            existingResponseRegistReply.SetUpdate(_user,0);
            _ResponseRegistReplyRepository.Update(existingResponseRegistReply);
            await _ResponseRegistReplyRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateResponseRegistReplyCommandResponse>(existingResponseRegistReply);
            return methodResult;
        }
    }
}