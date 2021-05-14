using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateStepsProcessCommandHandler : StepsProcessCommandHandler,IRequestHandler<UpdateStepsProcessCommand, MethodResult<UpdateStepsProcessCommandResponse>>
    {
        public UpdateStepsProcessCommandHandler(IMapper mapper, IStepsProcessRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing StepsProcess.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateStepsProcessCommandResponse>> Handle(UpdateStepsProcessCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateStepsProcessCommandResponse>();
            var existingStepsProcess = await _StepsProcessRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingStepsProcess == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingStepsProcess.IsActive = request.IsActive.HasValue ? request.IsActive : existingStepsProcess.IsActive;
            existingStepsProcess.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingStepsProcess.IsVisible;
            existingStepsProcess.Status = request.Status.HasValue ? request.Status : existingStepsProcess.Status;

            existingStepsProcess.SetCode(request.Code);
            existingStepsProcess.SetTitle(request.Title);
            existingStepsProcess.SetPriority(request.Priority);
            existingStepsProcess.SetParentId(request.ParentId);
            existingStepsProcess.SetLevel(request.Level);
            existingStepsProcess.SetPreviousId(request.PreviousId);
            existingStepsProcess.SetNextId(request.NextId);
            existingStepsProcess.SetOperationProcessId(request.OperationProcessId);

            existingStepsProcess.SetUpdate(_user,null);
            _StepsProcessRepository.Update(existingStepsProcess);
            await _StepsProcessRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateStepsProcessCommandResponse>(existingStepsProcess);
            return methodResult;
        }
    }
}