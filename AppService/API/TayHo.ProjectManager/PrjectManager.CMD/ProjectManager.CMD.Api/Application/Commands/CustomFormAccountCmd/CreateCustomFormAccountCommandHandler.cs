using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateCustomFormAccountCommandHandler : CustomFormAccountCommandHandler, IRequestHandler<CreateCustomFormAccountCommand, MethodResult<CreateCustomFormAccountCommandResponse>>
    {
        public CreateCustomFormAccountCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,ICustomFormAccountRepository customFormAccountRepository) : base(mapper, httpContextAccessor, customFormAccountRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new CustomFormAccount
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateCustomFormAccountCommandResponse>> Handle(CreateCustomFormAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateCustomFormAccountCommandResponse>();
            var newCustomFormAccount = new CustomFormAccount(request.CustomFormId,request.AccountId,request.GroupId);
            newCustomFormAccount.SetCreate(_user);
            newCustomFormAccount.Status = request.Status.HasValue ? request.Status : newCustomFormAccount.Status;
            newCustomFormAccount.IsActive = request.IsActive.HasValue ? request.IsActive : newCustomFormAccount.IsActive;
            newCustomFormAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newCustomFormAccount.IsVisible;
            await _customFormAccountRepository.AddAsync(newCustomFormAccount).ConfigureAwait(false);
            await _customFormAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateCustomFormAccountCommandResponse>(newCustomFormAccount);
            return methodResult;
        }
    }
}
