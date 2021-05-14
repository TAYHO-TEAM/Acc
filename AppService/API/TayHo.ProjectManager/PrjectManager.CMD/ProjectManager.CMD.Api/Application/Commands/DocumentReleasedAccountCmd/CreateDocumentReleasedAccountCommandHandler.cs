using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProjectManager.CMD.Domain.IService;
using System.Linq;
using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateDocumentReleasedAccountCommandHandler : DocumentReleasedAccountCommandHandler, IRequestHandler<CreateDocumentReleasedAccountCommand, MethodResult<CreateDocumentReleasedAccountCommandResponse>>
    {
        private readonly IGroupAccountRepository _groupAccount;
        private readonly IDocumentReleasedRepository _documentReleasedRepository;
        private readonly ISendMailService _sendMailService;
        private readonly IAccountInfoRepository _accountInfoRepository;
        public CreateDocumentReleasedAccountCommandHandler(IMapper mapper, IDocumentReleasedAccountRepository DocumentReleasedAccountRepository, IHttpContextAccessor httpContextAccessor, IGroupAccountRepository GroupAccount, IDocumentReleasedRepository DocumentReleasedRepository, ISendMailService SendMailService, IAccountInfoRepository AccountInfoRepository) : base(mapper, DocumentReleasedAccountRepository, httpContextAccessor)
        {
            _groupAccount = GroupAccount;
            _documentReleasedRepository = DocumentReleasedRepository;
            _sendMailService = SendMailService;
            _accountInfoRepository = AccountInfoRepository;
        }

        /// <summary>
        /// Handle for creating a new DocumentReleasedAccount
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateDocumentReleasedAccountCommandResponse>> Handle(CreateDocumentReleasedAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateDocumentReleasedAccountCommandResponse>();
            List<DocumentReleasedAccount> newDocumentReleasedAccounts = new List<DocumentReleasedAccount>();
            var existingGroupAccounts = await _groupAccount.GetAllListAsync(x => x.GroupId == (request.GroupId.HasValue ? request.GroupId : 0) && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false);
            if (request.GroupId.HasValue && existingGroupAccounts != null)
            {
                if (existingGroupAccounts.Count > 0)
                {
                    foreach (var groupAccount in existingGroupAccounts)
                    {
                        if (!await _documentReleasedAccountRepository.AnyAsync(x => x.AccountId == groupAccount.AccountId && x.DocumentReleasedId == request.DocumentReleasedId && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false))
                        {
                            var newDocumentReleasedAccount = new DocumentReleasedAccount(groupAccount.AccountId,
                                                                                   request.DocumentReleasedId,
                                                                                   request.GroupId);
                            newDocumentReleasedAccount.SetCreate(_user);
                            newDocumentReleasedAccount.Status = request.Status.HasValue ? request.Status : 0;
                            newDocumentReleasedAccount.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                            newDocumentReleasedAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
                            newDocumentReleasedAccounts.Add(newDocumentReleasedAccount);
                        }
                    }
                }
            }
            else if (request.AccountId > 0)
            {
                if (!await _documentReleasedAccountRepository.AnyAsync(x => x.AccountId == request.AccountId && x.DocumentReleasedId == request.DocumentReleasedId && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false))
                {
                    var newDocumentReleasedAccount = new DocumentReleasedAccount(request.AccountId,
                                                                             request.DocumentReleasedId,
                                                                             request.GroupId);
                    newDocumentReleasedAccount.SetCreate(_user);
                    newDocumentReleasedAccount.Status = request.Status.HasValue ? request.Status : 0;
                    newDocumentReleasedAccount.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                    newDocumentReleasedAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
                    newDocumentReleasedAccounts.Add(newDocumentReleasedAccount);
                }
            }
            await _documentReleasedAccountRepository.AddRangeAsync(newDocumentReleasedAccounts).ConfigureAwait(false);
            await _documentReleasedAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            await _documentReleasedRepository.DocumentReleasedProcessAsync();
            if (newDocumentReleasedAccounts.Count > 0)
            {
                List<string> toMails = await _documentReleasedRepository.IsGetToMailsAsync((int)(request.DocumentReleasedId));
                var documentRealesed = await _documentReleasedRepository.SingleOrDefaultAsync(x => x.Id == request.DocumentReleasedId).ConfigureAwait(false);
                if (documentRealesed.DocumentTypeId == 8)
                {
                    _sendMailService.SendMailAppoinment((documentRealesed.Calendar.HasValue? (DateTime)documentRealesed.Calendar:DateTime.Now), (documentRealesed.Calendar.HasValue ? (DateTime)documentRealesed.Calendar : DateTime.Now), documentRealesed.Location, documentRealesed.Title, documentRealesed.Description, documentRealesed.Title, "", toMails, null, null, false);
                }
            }

            //if (request.AccountId.HasValue && request.AccountId > 0)
            //{
            //    var accountInfo = await _accountInfoRepository.GetAllListAsync(x => x.AccountId == request.AccountId).ConfigureAwait(false);
            //    var documentRealesed = await _documentReleasedRepository.SingleOrDefaultAsync(x => x.Id == request.DocumentReleasedId).ConfigureAwait(false);
            //}
            var DocumentReleasedAccountResponseDTOs = _mapper.Map<List<DocumentReleasedAccountCommandResponseDTO>>(newDocumentReleasedAccounts);
            methodResult.Result = new CreateDocumentReleasedAccountCommandResponse(DocumentReleasedAccountResponseDTOs);
            return methodResult;
        }
    }
}