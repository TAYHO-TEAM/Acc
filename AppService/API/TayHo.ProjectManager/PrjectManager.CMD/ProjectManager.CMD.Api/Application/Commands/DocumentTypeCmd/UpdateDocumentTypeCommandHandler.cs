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
    public class UpdateDocumentTypeCommandHandler : DocumentTypeCommandHandler,IRequestHandler<UpdateDocumentTypeCommand, MethodResult<UpdateDocumentTypeCommandResponse>>
    {
        public UpdateDocumentTypeCommandHandler(IMapper mapper, IDocumentTypeRepository DocumentTypeRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, DocumentTypeRepository,httpContextAccessor)
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
            var existingStage = await _DocumentTypeRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingStage == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingStage.IsActive = request.IsActive.HasValue ? request.IsActive : existingStage.IsActive;
            existingStage.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingStage.IsVisible;
            existingStage.Status = request.Status.HasValue ? request.Status : existingStage.Status;
            existingStage.SetCode(request.Code);
            existingStage.SetDescription(request.Descriptions);
            existingStage.SetOperationProcessId(request.OperationProcessId);
            existingStage.SetTitle(request.Title);
            existingStage.SetUpdate(_user,0);
            _DocumentTypeRepository.Update(existingStage);
            await _DocumentTypeRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateDocumentTypeCommandResponse>(existingStage);
            return methodResult;
        }
    }
}