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
    public class DeleteCustomFormAccountCommandHandler : CustomFormAccountCommandHandler, IRequestHandler<DeleteCustomFormAccountCommand, MethodResult<DeleteCustomFormAccountCommandResponse>>
    {
        public DeleteCustomFormAccountCommandHandler(IMapper mapper, ICustomFormAccountRepository CustomFormAccountRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, CustomFormAccountRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing CustomFormAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteCustomFormAccountCommandResponse>> Handle(DeleteCustomFormAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteCustomFormAccountCommandResponse>();
            var existingCustomFormAccounts = await _customFormAccountRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomFormAccounts == null || !existingCustomFormAccounts.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingCustomFormAccount in existingCustomFormAccounts)
            {
                existingCustomFormAccount.UpdateDate = now;
                existingCustomFormAccount.UpdateDateUTC = utc;
                existingCustomFormAccount.IsDelete = true;
                existingCustomFormAccount.SetUpdate(_user, null);
            }
            _customFormAccountRepository.UpdateRange(existingCustomFormAccounts);
            await _customFormAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var CustomFormAccountResponseDTOs = _mapper.Map<List<CustomFormAccountCommandResponseDTO>>(existingCustomFormAccounts);
            methodResult.Result = new DeleteCustomFormAccountCommandResponse(CustomFormAccountResponseDTOs);
            return methodResult;
        }
    }
}
