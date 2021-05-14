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
    public class DeleteDocumentReleasedAccountCommandHandler : DocumentReleasedAccountCommandHandler, IRequestHandler<DeleteDocumentReleasedAccountCommand, MethodResult<DeleteDocumentReleasedAccountCommandResponse>>
    {
        public DeleteDocumentReleasedAccountCommandHandler(IMapper mapper, IDocumentReleasedAccountRepository DocumentReleasedAccountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, DocumentReleasedAccountRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing DocumentReleasedAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteDocumentReleasedAccountCommandResponse>> Handle(DeleteDocumentReleasedAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteDocumentReleasedAccountCommandResponse>();
            var existingDocumentReleasedAccount = await _documentReleasedAccountRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingDocumentReleasedAccount == null || !existingDocumentReleasedAccount.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStage in existingDocumentReleasedAccount)
            {
                existingStage.UpdateDate = now;
                existingStage.UpdateDateUTC = utc;
                existingStage.IsDelete = true;
                existingStage.ModifyBy = 0;
                existingStage.SetUpdate(_user,0);
                
            }
            _documentReleasedAccountRepository.UpdateRange(existingDocumentReleasedAccount);
            await _documentReleasedAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var DocumentReleasedAccountResponseDTOs = _mapper.Map<List<DocumentReleasedAccountCommandResponseDTO>>(existingDocumentReleasedAccount);
            methodResult.Result = new DeleteDocumentReleasedAccountCommandResponse(DocumentReleasedAccountResponseDTOs);
            return methodResult;
        }
    }
}