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
    public class DeleteDocumentReleasedLogCommandHandler : DocumentReleasedLogCommandHandler, IRequestHandler<DeleteDocumentReleasedLogCommand, MethodResult<DeleteDocumentReleasedLogCommandResponse>>
    {
        public DeleteDocumentReleasedLogCommandHandler(IMapper mapper, IDocumentReleasedLogRepository DocumentReleasedLogRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, DocumentReleasedLogRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing DocumentReleasedLog.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteDocumentReleasedLogCommandResponse>> Handle(DeleteDocumentReleasedLogCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteDocumentReleasedLogCommandResponse>();
            var existingDocumentReleasedLog = await _DocumentReleasedLogRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingDocumentReleasedLog == null || !existingDocumentReleasedLog.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStage in existingDocumentReleasedLog)
            {
                existingStage.UpdateDate = now;
                existingStage.UpdateDateUTC = utc;
                existingStage.IsDelete = true;
                existingStage.ModifyBy = 0;
                existingStage.SetUpdate(_user,0);
                
            }
            _DocumentReleasedLogRepository.UpdateRange(existingDocumentReleasedLog);
            await _DocumentReleasedLogRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var DocumentReleasedLogResponseDTOs = _mapper.Map<List<DocumentReleasedLogCommandResponseDTO>>(existingDocumentReleasedLog);
            methodResult.Result = new DeleteDocumentReleasedLogCommandResponse(DocumentReleasedLogResponseDTOs);
            return methodResult;
        }
    }
}