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
    public class CreateDocumentReleasedAccountsCommandHandler : DocumentReleasedAccountCommandHandler, IRequestHandler<CreateDocumentReleasedAccountsCommand, MethodResult<CreateDocumentReleasedAccountCommandResponse>>
    {
        private readonly IGroupAccountRepository _groupAccount;
        private readonly IDocumentReleasedRepository _documentReleasedRepository;
        private readonly IDocumentReleasedLogRepository _documentReleasedLogRepository;
        private readonly ISendMailService _sendMailService;
        private readonly IAccountInfoRepository _accountInfoRepository;
        public CreateDocumentReleasedAccountsCommandHandler(IMapper mapper, IDocumentReleasedAccountRepository DocumentReleasedAccountRepository, IHttpContextAccessor httpContextAccessor, IGroupAccountRepository GroupAccount, IDocumentReleasedRepository DocumentReleasedRepository, ISendMailService SendMailService, IAccountInfoRepository AccountInfoRepository, IDocumentReleasedLogRepository documentReleasedLogRepository) : base(mapper, DocumentReleasedAccountRepository, httpContextAccessor)
        {
            _groupAccount = GroupAccount;
            _documentReleasedRepository = DocumentReleasedRepository;
            _sendMailService = SendMailService;
            _accountInfoRepository = AccountInfoRepository;
            _documentReleasedLogRepository = documentReleasedLogRepository;
        }

        /// <summary>
        /// Handle for creating a new DocumentReleasedAccount
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateDocumentReleasedAccountCommandResponse>> Handle(CreateDocumentReleasedAccountsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateDocumentReleasedAccountCommandResponse>();
            List<DocumentReleasedAccount> newDocumentReleasedAccounts = new List<DocumentReleasedAccount>();
            List<DocumentReleasedLog> newDocumentReleasedLogs = new List<DocumentReleasedLog>();

            //var existingGroupAccounts = await _groupAccount.GetAllListAsync(x => x.GroupId == groupId && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false);

            foreach (var accountId in request.AccountIds)
            {
                if (!await _documentReleasedAccountRepository.AnyAsync(x => x.AccountId == accountId && x.DocumentReleasedId == request.DocumentReleasedId && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false))
                {
                    var newDocumentReleasedAccount = new DocumentReleasedAccount(accountId,
                                                                            request.DocumentReleasedId,
                                                                            0);
                    newDocumentReleasedAccount.SetCreate(_user);
                    newDocumentReleasedAccount.Status = request.Status.HasValue ? request.Status : 0;
                    newDocumentReleasedAccount.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                    newDocumentReleasedAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
                    newDocumentReleasedAccounts.Add(newDocumentReleasedAccount);
                    var newDocumentReleasedLog = new DocumentReleasedLog(accountId,
                                                                            request.DocumentReleasedId,
                                                                            "");
                    newDocumentReleasedLog.SetCreate(_user);
                    newDocumentReleasedLog.Status =  1;
                    newDocumentReleasedLog.IsActive = true;
                    newDocumentReleasedLog.IsVisible = true;
                    newDocumentReleasedLogs.Add(newDocumentReleasedLog);
                }
            }
            await _documentReleasedAccountRepository.AddRangeAsync(newDocumentReleasedAccounts).ConfigureAwait(false);
            await _documentReleasedAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            //await _documentReleasedRepository.DocumentReleasedProcessAsync();
            if (newDocumentReleasedAccounts.Count > 0)
            {
                List<string> toMails = await _documentReleasedRepository.IsGetToMailsAsync((int)(request.DocumentReleasedId));
                var documentRealesed = await _documentReleasedRepository.SingleOrDefaultAsync(x => x.Id == request.DocumentReleasedId).ConfigureAwait(false);
                if (documentRealesed.DocumentTypeId == 8)
                {
                    try
                    {
                        _sendMailService.SendMailAppoinment((documentRealesed.Calendar.HasValue ? (DateTime)documentRealesed.Calendar : DateTime.Now), (documentRealesed.Calendar.HasValue ? (DateTime)documentRealesed.Calendar : DateTime.Now), documentRealesed.Location, documentRealesed.Title, documentRealesed.Description, documentRealesed.Title, "", toMails, null, null, false);
                    }
                    catch
                    {
                        
                    }
                    
                }
                else if (documentRealesed.DocumentTypeId == 7)
                {
                    string body = await _documentReleasedRepository.GetBodyContentWithTempId((int)request.DocumentReleasedId, 2);
                    body = body.Replace("{Dear}","Kính gửi Anh(Chị)!").Replace("{TitleContent}", "Phát hành tài liệu.");
                    try
                    {
                        _sendMailService.SendMail(documentRealesed.Title, body, "", "", toMails, null, null, true);
                    }
                    catch
                    {
                        
                    }
                }
                await _documentReleasedLogRepository.AddRangeAsync(newDocumentReleasedLogs).ConfigureAwait(false);
                await _documentReleasedLogRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

            var DocumentReleasedAccountResponseDTOs = _mapper.Map<List<DocumentReleasedAccountCommandResponseDTO>>(newDocumentReleasedAccounts);
            methodResult.Result = new CreateDocumentReleasedAccountCommandResponse(DocumentReleasedAccountResponseDTOs);
            return methodResult;
        }
    }
}