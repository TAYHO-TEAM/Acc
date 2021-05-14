using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class DeleteDocumentTypeCommandHandler : DocumentTypeCommandHandler, IRequestHandler<DeleteDocumentTypeCommand, MethodResult<DeleteDocumentTypeCommandResponse>>
    {
        public DeleteDocumentTypeCommandHandler(IMapper mapper, IDocumentTypeRepository DocumentTypeRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, DocumentTypeRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing DocumentType.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteDocumentTypeCommandResponse>> Handle(DeleteDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteDocumentTypeCommandResponse>();
            var existingDocumentTypes = await _DocumentTypeRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingDocumentTypes == null || !existingDocumentTypes.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingDocumentType in existingDocumentTypes)
            {
                existingDocumentType.UpdateDate = now;
                existingDocumentType.UpdateDateUTC = utc;
                existingDocumentType.IsDelete = true;
                existingDocumentType.SetUpdate(_user, null);
            }
            _DocumentTypeRepository.UpdateRange(existingDocumentTypes);
            await _DocumentTypeRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var DocumentTypeResponseDTOs = _mapper.Map<List<DocumentTypeCommandResponseDTO>>(existingDocumentTypes);
            methodResult.Result = new DeleteDocumentTypeCommandResponse(DocumentTypeResponseDTOs);
            return methodResult;
        }
    }
}