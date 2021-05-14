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
    public class UpdateOperationProcessCommandHandler : OperationProcessCommandHandler,IRequestHandler<UpdateOperationProcessCommand, MethodResult<UpdateOperationProcessCommandResponse>>
    {
        public UpdateOperationProcessCommandHandler(IMapper mapper, IOperationProcessRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing OperationProcess.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateOperationProcessCommandResponse>> Handle(UpdateOperationProcessCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateOperationProcessCommandResponse>();
            var existingOperationProcess = await _OperationProcessRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingOperationProcess == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingOperationProcess.IsActive = request.IsActive.HasValue ? request.IsActive : existingOperationProcess.IsActive;
            existingOperationProcess.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingOperationProcess.IsVisible;
            existingOperationProcess.Status = request.Status.HasValue ? request.Status : existingOperationProcess.Status;

            existingOperationProcess.SetCode(request.Code);
            existingOperationProcess.SetBarCode(request.BarCode);
            existingOperationProcess.SetTitle(request.Title);
            existingOperationProcess.SetDescription(request.Description);
            existingOperationProcess.SetPriority(request.Priority);
            existingOperationProcess.SetParentId(request.ParentId);
            existingOperationProcess.SetLevel(request.Level);
            existingOperationProcess.SetPreviousId(request.PreviousId);
            existingOperationProcess.SetNextId(request.NextId);

            existingOperationProcess.SetUpdate(_user,null);
            _OperationProcessRepository.Update(existingOperationProcess);
            await _OperationProcessRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateOperationProcessCommandResponse>(existingOperationProcess);
            return methodResult;
        }
    }
}