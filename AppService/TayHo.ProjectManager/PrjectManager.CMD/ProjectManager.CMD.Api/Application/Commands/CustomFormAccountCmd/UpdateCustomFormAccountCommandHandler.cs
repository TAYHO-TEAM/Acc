using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateCustomFormAccountCommandHandler : CustomFormAccountCommandHandler,IRequestHandler<UpdateCustomFormAccountCommand, MethodResult<UpdateCustomFormAccountCommandResponse>>
    {
        public UpdateCustomFormAccountCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor, ICustomFormAccountRepository customFormAccountRepository) : base(mapper,httpContextAccessor,customFormAccountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing CustomFormAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateCustomFormAccountCommandResponse>> Handle(UpdateCustomFormAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateCustomFormAccountCommandResponse>();
            var existingCustomFormAccount = await _customFormAccountRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomFormAccount == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingCustomFormAccount.IsActive = request.IsActive.HasValue ? request.IsActive : existingCustomFormAccount.IsActive;
            existingCustomFormAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingCustomFormAccount.IsVisible;
            existingCustomFormAccount.Status = request.Status.HasValue ? request.Status : existingCustomFormAccount.Status;

            existingCustomFormAccount.SetCustomFormId(request.CustomFormId);
	existingCustomFormAccount.SetAccountId(request.AccountId);
			existingCustomFormAccount.SetGroupId(request.GroupId);
			

            existingCustomFormAccount.SetUpdate(_user,null);
            _customFormAccountRepository.Update(existingCustomFormAccount);
            await _customFormAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateCustomFormAccountCommandResponse>(existingCustomFormAccount);
            return methodResult;
        }
    }
}
