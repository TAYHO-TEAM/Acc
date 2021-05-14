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
    public class DeleteDocumentReleasedCommandHandler : DocumentReleasedCommandHandler, IRequestHandler<DeleteDocumentReleasedCommand, MethodResult<DeleteDocumentReleasedCommandResponse>>
    {
        public DeleteDocumentReleasedCommandHandler(IMapper mapper, IDocumentReleasedRepository DocumentReleasedRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, DocumentReleasedRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing DocumentReleased.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteDocumentReleasedCommandResponse>> Handle(DeleteDocumentReleasedCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteDocumentReleasedCommandResponse>();
            var existingDocumentReleased = await _documentReleasedRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingDocumentReleased == null || !existingDocumentReleased.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStage in existingDocumentReleased)
            {
                existingStage.UpdateDate = now;
                existingStage.UpdateDateUTC = utc;
                existingStage.IsDelete = true;
                existingStage.ModifyBy = 0;
                existingStage.SetUpdate(_user,0);
                
            }
            _documentReleasedRepository.UpdateRange(existingDocumentReleased);
            await _documentReleasedRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var DocumentReleasedResponseDTOs = _mapper.Map<List<DocumentReleasedCommandResponseDTO>>(existingDocumentReleased);
            methodResult.Result = new DeleteDocumentReleasedCommandResponse(DocumentReleasedResponseDTOs);
            return methodResult;
        }
    }
}