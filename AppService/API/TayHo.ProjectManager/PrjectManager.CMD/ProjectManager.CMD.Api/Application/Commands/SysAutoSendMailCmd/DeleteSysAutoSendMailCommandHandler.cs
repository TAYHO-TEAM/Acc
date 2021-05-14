using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
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

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteSysAutoSendMailCommandHandler : SysAutoSendMailCommandHandler, IRequestHandler<DeleteSysAutoSendMailCommand, MethodResult<DeleteSysAutoSendMailCommandResponse>>
    {
        public DeleteSysAutoSendMailCommandHandler(IMapper mapper, ISysAutoSendMailRepository SysAutoSendMailRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, SysAutoSendMailRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing SysAutoSendMail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteSysAutoSendMailCommandResponse>> Handle(DeleteSysAutoSendMailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteSysAutoSendMailCommandResponse>();
            var existingSysAutoSendMails = await _sysAutoSendMailRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingSysAutoSendMails == null || !existingSysAutoSendMails.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingSysAutoSendMail in existingSysAutoSendMails)
            {
                existingSysAutoSendMail.UpdateDate = now;
                existingSysAutoSendMail.UpdateDateUTC = utc;
                existingSysAutoSendMail.IsDelete = true;
                existingSysAutoSendMail.SetUpdate(_user, null);
            }
            _sysAutoSendMailRepository.UpdateRange(existingSysAutoSendMails);
            await _sysAutoSendMailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var SysAutoSendMailResponseDTOs = _mapper.Map<List<SysAutoSendMailCommandResponseDTO>>(existingSysAutoSendMails);
            methodResult.Result = new DeleteSysAutoSendMailCommandResponse(SysAutoSendMailResponseDTOs);
            return methodResult;
        }
    }
}
