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
    public class DeleteResponseRegistReplyCommandHandler : ResponseRegistReplyCommandHandler, IRequestHandler<DeleteResponseRegistReplyCommand, MethodResult<DeleteResponseRegistReplyCommandResponse>>
    {
        public DeleteResponseRegistReplyCommandHandler(IMapper mapper, IResponseRegistReplyRepository ResponseRegistReplyRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, ResponseRegistReplyRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing ResponseRegistReply.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteResponseRegistReplyCommandResponse>> Handle(DeleteResponseRegistReplyCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteResponseRegistReplyCommandResponse>();
            var existingResponseRegistReplys = await _ResponseRegistReplyRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingResponseRegistReplys == null || !existingResponseRegistReplys.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingResponseRegistReply in existingResponseRegistReplys)
            {
                existingResponseRegistReply.UpdateDate = now;
                existingResponseRegistReply.UpdateDateUTC = utc;
                existingResponseRegistReply.IsDelete = true;
                existingResponseRegistReply.ModifyBy = 0;
                existingResponseRegistReply.SetUpdate(_user,0);
                
            }
            _ResponseRegistReplyRepository.UpdateRange(existingResponseRegistReplys);

            await _ResponseRegistReplyRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var ResponseRegistReplyResponseDTOs = _mapper.Map<List<ResponseRegistReplyCommandResponseDTO>>(existingResponseRegistReplys);
            methodResult.Result = new DeleteResponseRegistReplyCommandResponse(ResponseRegistReplyResponseDTOs);
            return methodResult;
        }
    }
}