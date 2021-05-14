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
    public class UpdateGroupStepProcessPermistionCommandHandler : GroupStepProcessPermistionCommandHandler,IRequestHandler<UpdateGroupStepProcessPermistionCommand, MethodResult<UpdateGroupStepProcessPermistionCommandResponse>>
    {
        public UpdateGroupStepProcessPermistionCommandHandler(IMapper mapper, IGroupStepProcessPermistionRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing GroupStepProcessPermistion.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateGroupStepProcessPermistionCommandResponse>> Handle(UpdateGroupStepProcessPermistionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateGroupStepProcessPermistionCommandResponse>();
            var existingGroupStepProcessPermistion = await _GroupStepProcessPermistionRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupStepProcessPermistion == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingGroupStepProcessPermistion.IsActive = request.IsActive.HasValue ? request.IsActive : existingGroupStepProcessPermistion.IsActive;
            existingGroupStepProcessPermistion.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingGroupStepProcessPermistion.IsVisible;
            existingGroupStepProcessPermistion.Status = request.Status.HasValue ? request.Status : existingGroupStepProcessPermistion.Status;

            existingGroupStepProcessPermistion.SetGroupId(request.GroupId);
            existingGroupStepProcessPermistion.SetStepProcessId(request.StepProcessId);
            existingGroupStepProcessPermistion.SetPermistion(request.Permistion);

            existingGroupStepProcessPermistion.SetUpdate(_user,null);
            _GroupStepProcessPermistionRepository.Update(existingGroupStepProcessPermistion);
            await _GroupStepProcessPermistionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateGroupStepProcessPermistionCommandResponse>(existingGroupStepProcessPermistion);
            return methodResult;
        }
    }
}