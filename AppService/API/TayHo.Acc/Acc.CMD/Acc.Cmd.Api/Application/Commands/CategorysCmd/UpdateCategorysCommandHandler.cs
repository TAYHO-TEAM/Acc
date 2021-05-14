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
    public class UpdateCategorysCommandHandler : CategorysCommandHandler,IRequestHandler<UpdateCategorysCommand, MethodResult<UpdateCategorysCommandResponse>>
    {
        public UpdateCategorysCommandHandler(IMapper mapper, ICategorysRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing Categorys.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateCategorysCommandResponse>> Handle(UpdateCategorysCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateCategorysCommandResponse>();
            var existingCategorys = await _CategorysRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingCategorys == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingCategorys.IsActive = request.IsActive.HasValue ? request.IsActive : existingCategorys.IsActive;
            existingCategorys.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingCategorys.IsVisible;
            existingCategorys.Status = request.Status.HasValue ? request.Status : existingCategorys.Status;
            existingCategorys.SetTitle(request.Title);
            existingCategorys.SetDescriptions(request.Descriptions);
            existingCategorys.SetUpdate(0,0);
            _CategorysRepository.Update(existingCategorys);
            await _CategorysRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateCategorysCommandResponse>(existingCategorys);
            return methodResult;
        }
    }
}