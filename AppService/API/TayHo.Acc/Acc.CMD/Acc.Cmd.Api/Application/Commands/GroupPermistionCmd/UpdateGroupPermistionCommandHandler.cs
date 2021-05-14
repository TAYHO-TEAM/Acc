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
    public class UpdateGroupPermistionCommandHandler : GroupPermistionCommandHandler,IRequestHandler<UpdateGroupPermistionCommand, MethodResult<UpdateGroupPermistionCommandResponse>>
    {
        public UpdateGroupPermistionCommandHandler(IMapper mapper, IGroupPermistionRepository PermistionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, PermistionRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing GroupPermistion.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateGroupPermistionCommandResponse>> Handle(UpdateGroupPermistionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateGroupPermistionCommandResponse>();
            var existingGroupPermistion = await _GroupPermistionRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupPermistion == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingGroupPermistion.IsActive = request.IsActive.HasValue ? request.IsActive : existingGroupPermistion.IsActive;
            existingGroupPermistion.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingGroupPermistion.IsVisible;
            existingGroupPermistion.Status = request.Status.HasValue ? request.Status : existingGroupPermistion.Status;
            existingGroupPermistion.SetPermistionId(request.PermistionId);
            existingGroupPermistion.SetGroupId(request.GroupId);

            existingGroupPermistion.SetUpdate(_user,null);
            _GroupPermistionRepository.Update(existingGroupPermistion);
            await _GroupPermistionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateGroupPermistionCommandResponse>(existingGroupPermistion);
            return methodResult;
        }
    }
}