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

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateDocumentReleasedAccountCommandHandler : DocumentReleasedAccountCommandHandler, IRequestHandler<UpdateDocumentReleasedAccountCommand, MethodResult<UpdateDocumentReleasedAccountCommandResponse>>
    {
        private readonly IGroupAccountRepository _groupAccount;
        public UpdateDocumentReleasedAccountCommandHandler(IMapper mapper, IDocumentReleasedAccountRepository DocumentReleasedAccountRepository, IHttpContextAccessor httpContextAccessor, IGroupAccountRepository GroupAccount) : base(mapper, DocumentReleasedAccountRepository, httpContextAccessor)
        {
            _groupAccount = GroupAccount;
        }

        /// <summary>
        /// Handle for update a existing DocumentReleasedAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateDocumentReleasedAccountCommandResponse>> Handle(UpdateDocumentReleasedAccountCommand request, CancellationToken cancellationToken)
        {
            ///// kiểm tra account có tồn tại trong group nếu có truyền group id
            var existingGroupAccount = await _groupAccount.AnyAsync(x => x.GroupId == request.GroupId && x.AccountId == request.AccountId && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false);
            var methodResult = new MethodResult<UpdateDocumentReleasedAccountCommandResponse>();
            var existingDocumentReleasedAccount = await _documentReleasedAccountRepository.SingleOrDefaultAsync(x => x.Id == request.Id && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false);
            var duplicateDocumentReleasedAccount = await _documentReleasedAccountRepository.AnyAsync(x => x.Id != request.Id && (x.IsDelete == false || !x.IsDelete.HasValue) && x.AccountId == request.AccountId && x.DocumentReleasedId == request.DocumentReleasedId).ConfigureAwait(false);
            if (duplicateDocumentReleasedAccount)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr03), new[]
                {
                    ErrorHelpers.GetCommonErrorMessage(nameof(ErrorCodeUpdate.UErr03))
                });
            }
            if (existingDocumentReleasedAccount == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GetCommonErrorMessage(nameof(ErrorCodeUpdate.UErr01))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingDocumentReleasedAccount.IsActive = request.IsActive.HasValue ? request.IsActive : existingDocumentReleasedAccount.IsActive;
            existingDocumentReleasedAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingDocumentReleasedAccount.IsVisible;
            existingDocumentReleasedAccount.Status = request.Status.HasValue ? request.Status : existingDocumentReleasedAccount.Status;
            existingDocumentReleasedAccount.SetAccountId(request.AccountId);
            existingDocumentReleasedAccount.SetDocumentReleasedId(request.DocumentReleasedId);
            existingDocumentReleasedAccount.SetGroupId(request.GroupId);

            existingDocumentReleasedAccount.SetUpdate(_user, 0);
            _documentReleasedAccountRepository.Update(existingDocumentReleasedAccount);
            await _documentReleasedAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateDocumentReleasedAccountCommandResponse>(existingDocumentReleasedAccount);
            return methodResult;
        }
    }
}