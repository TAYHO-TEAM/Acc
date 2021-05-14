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

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteReplyCommandHandler : ReplyCommandHandler, IRequestHandler<DeleteReplyCommand, MethodResult<DeleteReplyCommandResponse>>
    {
        public DeleteReplyCommandHandler(IMapper mapper, IReplyRepository ReplyRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, ReplyRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Reply.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteReplyCommandResponse>> Handle(DeleteReplyCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteReplyCommandResponse>();
            var existingReplys = await _ReplyRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingReplys == null || !existingReplys.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingReply in existingReplys)
            {
                existingReply.UpdateDate = now;
                existingReply.UpdateDateUTC = utc;
                existingReply.IsDelete = true;
                existingReply.ModifyBy = 0;
                existingReply.SetUpdate(_user,0);
            }
            _ReplyRepository.UpdateRange(existingReplys);
            await _ReplyRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var ReplyResponseDTOs = _mapper.Map<List<ReplyCommandResponseDTO>>(existingReplys);
            methodResult.Result = new DeleteReplyCommandResponse(ReplyResponseDTOs);
            return methodResult;
        }
    }
}