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
    public class UpdateGroupAccountCommandHandler : GroupAccountCommandHandler,IRequestHandler<UpdateGroupAccountCommand, MethodResult<UpdateGroupAccountCommandResponse>>
    {
        public UpdateGroupAccountCommandHandler(IMapper mapper, IGroupAccountRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing GroupAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateGroupAccountCommandResponse>> Handle(UpdateGroupAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateGroupAccountCommandResponse>();
            var existingGroupAccount = await _GroupAccountRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupAccount == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingGroupAccount.IsActive = request.IsActive.HasValue ? request.IsActive : existingGroupAccount.IsActive;
            existingGroupAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingGroupAccount.IsVisible;
            existingGroupAccount.Status = request.Status.HasValue ? request.Status : existingGroupAccount.Status;
            existingGroupAccount.SetAccountId(request.AccountId);
            existingGroupAccount.SetGroupId(request.GroupId);

            existingGroupAccount.SetUpdate(_user,null);
            _GroupAccountRepository.Update(existingGroupAccount);
            await _GroupAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateGroupAccountCommandResponse>(existingGroupAccount);
            return methodResult;
        }
    }
}