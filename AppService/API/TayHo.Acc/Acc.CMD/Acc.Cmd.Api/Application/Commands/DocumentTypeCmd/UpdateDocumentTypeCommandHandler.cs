using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateDocumentTypeCommandHandler : DocumentTypeCommandHandler,IRequestHandler<UpdateDocumentTypeCommand, MethodResult<UpdateDocumentTypeCommandResponse>>
    {
        public UpdateDocumentTypeCommandHandler(IMapper mapper, IDocumentTypeRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing DocumentType.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateDocumentTypeCommandResponse>> Handle(UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateDocumentTypeCommandResponse>();
            var existingDocumentType = await _DocumentTypeRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingDocumentType == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingDocumentType.IsActive = request.IsActive.HasValue ? request.IsActive : existingDocumentType.IsActive;
            existingDocumentType.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingDocumentType.IsVisible;
            existingDocumentType.Status = request.Status.HasValue ? request.Status : existingDocumentType.Status;
            existingDocumentType.SetCode(request.Code);
            existingDocumentType.SetTitle(request.Title);
            existingDocumentType.SetDescriptions(request.Descriptions);
            existingDocumentType.SetOperationProcessId(request.OperationProcessId);
            existingDocumentType.SetUpdate(_user,null);
            _DocumentTypeRepository.Update(existingDocumentType);
            await _DocumentTypeRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateDocumentTypeCommandResponse>(existingDocumentType);
            return methodResult;
        }
    }
}