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

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupAccountCommandHandler : GroupAccountCommandHandler, IRequestHandler<DeleteGroupAccountCommand, MethodResult<DeleteGroupAccountCommandResponse>>
    {
        public DeleteGroupAccountCommandHandler(IMapper mapper, IGroupAccountRepository GroupAccountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupAccountRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing GroupAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteGroupAccountCommandResponse>> Handle(DeleteGroupAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteGroupAccountCommandResponse>();
            var existingGroupAccounts = await _GroupAccountRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupAccounts == null || !existingGroupAccounts.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingGroupAccount in existingGroupAccounts)
            {
                existingGroupAccount.UpdateDate = now;
                existingGroupAccount.UpdateDateUTC = utc;
                existingGroupAccount.IsDelete = true;
                existingGroupAccount.SetUpdate(_user, null);

            }
            _GroupAccountRepository.UpdateRange(existingGroupAccounts);
            await _GroupAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var GroupAccountResponseDTOs = _mapper.Map<List<GroupAccountCommandResponseDTO>>(existingGroupAccounts);
            methodResult.Result = new DeleteGroupAccountCommandResponse(GroupAccountResponseDTOs);
            return methodResult;
        }
    }
}