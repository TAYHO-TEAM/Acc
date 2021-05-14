using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateFunctionsCommandHandler : FunctionsCommandHandler,IRequestHandler<UpdateFunctionsCommand, MethodResult<UpdateFunctionsCommandResponse>>
    {
        public UpdateFunctionsCommandHandler(IMapper mapper, IFunctionsRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing Functions.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateFunctionsCommandResponse>> Handle(UpdateFunctionsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateFunctionsCommandResponse>();
            var existingFunctions = await _FunctionsRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingFunctions == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingFunctions.IsActive = request.IsActive.HasValue ? request.IsActive : existingFunctions.IsActive;
            existingFunctions.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingFunctions.IsVisible;
            existingFunctions.Status = request.Status.HasValue ? request.Status : existingFunctions.Status;
            existingFunctions.SetActionId(request.ActionId);
            existingFunctions.SetParentId(request.ParentId);
            existingFunctions.SetTitle(request.Title);
            existingFunctions.SetDescriptions(request.Descriptions);
            existingFunctions.SetIcon(request.Icon);
            existingFunctions.SetUrl(request.Url);
            existingFunctions.SetCategoryId(request.CategoryId);
            existingFunctions.SetLevel(request.Level);

            existingFunctions.SetUpdate(_user,null);
            _FunctionsRepository.Update(existingFunctions);
            await _FunctionsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateFunctionsCommandResponse>(existingFunctions);
            return methodResult;
        }
    }
}