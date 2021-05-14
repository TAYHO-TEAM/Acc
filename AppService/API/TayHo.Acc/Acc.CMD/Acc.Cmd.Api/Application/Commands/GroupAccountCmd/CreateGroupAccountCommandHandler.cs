using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using Acc.Cmd.Domain;
using Services.Common.Utilities;

namespace Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupAccountCommandHandler : GroupAccountCommandHandler, IRequestHandler<CreateGroupAccountCommand, MethodResult<CreateGroupAccountCommandResponse>>
    {
        public CreateGroupAccountCommandHandler(IMapper mapper, IGroupAccountRepository GroupAccountRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupAccountRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new GroupAccount
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateGroupAccountCommandResponse>> Handle(CreateGroupAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateGroupAccountCommandResponse>();
            if (!(await _GroupAccountRepository.AnyAsync(x => x.AccountId == request.AccountId && x.GroupId == request.GroupId && x.IsDelete == false).ConfigureAwait(false)))
            {
                var newGroupAccount = new GroupAccount(request.AccountId,
                                                    request.GroupId);
                newGroupAccount.SetCreate(_user);
                newGroupAccount.Status = request.Status.HasValue ? request.Status : newGroupAccount.Status;
                newGroupAccount.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                newGroupAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
                await _GroupAccountRepository.AddAsync(newGroupAccount).ConfigureAwait(false);
                await _GroupAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                methodResult.Result = _mapper.Map<CreateGroupAccountCommandResponse>(newGroupAccount);
            }
            else
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeInsert.IErr000), new[]
                 {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),string.Join(',',request.Id))
                });
            }    
            return methodResult;
        }
    }
}