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
    public class UpdateGroupFunctionPermistionCommandHandler : GroupFunctionPermistionCommandHandler,IRequestHandler<UpdateGroupFunctionPermistionCommand, MethodResult<UpdateGroupFunctionPermistionCommandResponse>>
    {
        public UpdateGroupFunctionPermistionCommandHandler(IMapper mapper, IGroupFunctionPermistionRepository FunctionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, FunctionRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing GroupFunctionPermistion.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateGroupFunctionPermistionCommandResponse>> Handle(UpdateGroupFunctionPermistionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateGroupFunctionPermistionCommandResponse>();
            var existingGroupFunctionPermistion = await _GroupFunctionPermistionRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupFunctionPermistion == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingGroupFunctionPermistion.IsActive = request.IsActive.HasValue ? request.IsActive : existingGroupFunctionPermistion.IsActive;
            existingGroupFunctionPermistion.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingGroupFunctionPermistion.IsVisible;
            existingGroupFunctionPermistion.Status = request.Status.HasValue ? request.Status : existingGroupFunctionPermistion.Status;
            existingGroupFunctionPermistion.SetGroupId(request.GroupId);
            existingGroupFunctionPermistion.SetFunctionId(request.FunctionId);
            existingGroupFunctionPermistion.SetPermistionId(request.PermistionId);

            existingGroupFunctionPermistion.SetUpdate(_user,null);
            _GroupFunctionPermistionRepository.Update(existingGroupFunctionPermistion);
            await _GroupFunctionPermistionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateGroupFunctionPermistionCommandResponse>(existingGroupFunctionPermistion);
            return methodResult;
        }
    }
}