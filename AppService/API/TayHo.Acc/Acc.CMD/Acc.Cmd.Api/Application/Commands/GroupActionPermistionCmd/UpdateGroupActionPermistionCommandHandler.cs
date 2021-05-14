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
    public class UpdateGroupActionPermistionCommandHandler : GroupActionPermistionCommandHandler,IRequestHandler<UpdateGroupActionPermistionCommand, MethodResult<UpdateGroupActionPermistionCommandResponse>>
    {
        public UpdateGroupActionPermistionCommandHandler(IMapper mapper, IGroupActionPermistionRepository PermistionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, PermistionRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing GroupActionPermistion.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateGroupActionPermistionCommandResponse>> Handle(UpdateGroupActionPermistionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateGroupActionPermistionCommandResponse>();
            var existingGroupActionPermistion = await _GroupActionPermistionRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupActionPermistion == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingGroupActionPermistion.IsActive = request.IsActive.HasValue ? request.IsActive : existingGroupActionPermistion.IsActive;
            existingGroupActionPermistion.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingGroupActionPermistion.IsVisible;
            existingGroupActionPermistion.Status = request.Status.HasValue ? request.Status : existingGroupActionPermistion.Status;
            existingGroupActionPermistion.SetActionId(request.ActionId);
            existingGroupActionPermistion.SetPermistionId(request.PermistionId);
            existingGroupActionPermistion.SetGroupId(request.GroupId);

            existingGroupActionPermistion.SetUpdate(_user,null);
            _GroupActionPermistionRepository.Update(existingGroupActionPermistion);
            await _GroupActionPermistionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateGroupActionPermistionCommandResponse>(existingGroupActionPermistion);
            return methodResult;
        }
    }
}