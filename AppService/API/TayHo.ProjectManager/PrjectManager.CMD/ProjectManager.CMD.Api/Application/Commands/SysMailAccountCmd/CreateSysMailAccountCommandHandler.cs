using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateSysMailAccountCommandHandler : SysMailAccountCommandHandler, IRequestHandler<CreateSysMailAccountCommand, MethodResult<CreateSysMailAccountCommandResponse>>
    {
        public CreateSysMailAccountCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,ISysMailAccountRepository sysMailAccountRepository) : base(mapper, httpContextAccessor, sysMailAccountRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new SysMailAccount
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateSysMailAccountCommandResponse>> Handle(CreateSysMailAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateSysMailAccountCommandResponse>();
            var newSysMailAccount = new SysMailAccount(request.SysAutoSendMailId,request.Email,request.Type);
            newSysMailAccount.SetCreate(_user);
            newSysMailAccount.Status = request.Status.HasValue ? request.Status : newSysMailAccount.Status;
            newSysMailAccount.IsActive = request.IsActive.HasValue ? request.IsActive : newSysMailAccount.IsActive;
            newSysMailAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newSysMailAccount.IsVisible;
            await _sysMailAccountRepository.AddAsync(newSysMailAccount).ConfigureAwait(false);
            await _sysMailAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateSysMailAccountCommandResponse>(newSysMailAccount);
            return methodResult;
        }
    }
}
