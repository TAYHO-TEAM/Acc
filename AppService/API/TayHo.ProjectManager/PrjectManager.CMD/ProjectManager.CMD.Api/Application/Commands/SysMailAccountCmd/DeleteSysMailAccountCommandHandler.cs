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
    public class DeleteSysMailAccountCommandHandler : SysMailAccountCommandHandler, IRequestHandler<DeleteSysMailAccountCommand, MethodResult<DeleteSysMailAccountCommandResponse>>
    {
        public DeleteSysMailAccountCommandHandler(IMapper mapper, ISysMailAccountRepository SysMailAccountRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, SysMailAccountRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing SysMailAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteSysMailAccountCommandResponse>> Handle(DeleteSysMailAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteSysMailAccountCommandResponse>();
            var existingSysMailAccounts = await _sysMailAccountRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingSysMailAccounts == null || !existingSysMailAccounts.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingSysMailAccount in existingSysMailAccounts)
            {
                existingSysMailAccount.UpdateDate = now;
                existingSysMailAccount.UpdateDateUTC = utc;
                existingSysMailAccount.IsDelete = true;
                existingSysMailAccount.SetUpdate(_user, null);
            }
            _sysMailAccountRepository.UpdateRange(existingSysMailAccounts);
            await _sysMailAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var SysMailAccountResponseDTOs = _mapper.Map<List<SysMailAccountCommandResponseDTO>>(existingSysMailAccounts);
            methodResult.Result = new DeleteSysMailAccountCommandResponse(SysMailAccountResponseDTOs);
            return methodResult;
        }
    }
}
