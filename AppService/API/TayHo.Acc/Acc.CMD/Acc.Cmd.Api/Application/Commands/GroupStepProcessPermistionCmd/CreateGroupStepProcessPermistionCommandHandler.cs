using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupStepProcessPermistionCommandHandler : GroupStepProcessPermistionCommandHandler, IRequestHandler<CreateGroupStepProcessPermistionCommand, MethodResult<CreateGroupStepProcessPermistionCommandResponse>>
    {
        public CreateGroupStepProcessPermistionCommandHandler(IMapper mapper, IGroupStepProcessPermistionRepository GroupStepProcessPermistionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupStepProcessPermistionRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new GroupStepProcessPermistion
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateGroupStepProcessPermistionCommandResponse>> Handle(CreateGroupStepProcessPermistionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateGroupStepProcessPermistionCommandResponse>();

            var newGroupStepProcessPermistion = new GroupStepProcessPermistion(request.GroupId,
                                                                                request.StepProcessId,
                                                                                request.Permistion);

            newGroupStepProcessPermistion.SetCreate(_user);
            newGroupStepProcessPermistion.Status = request.Status.HasValue ? request.Status : newGroupStepProcessPermistion.Status;
            newGroupStepProcessPermistion.IsActive = request.IsActive.HasValue ? request.IsActive : newGroupStepProcessPermistion.IsActive;
            newGroupStepProcessPermistion.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newGroupStepProcessPermistion.IsVisible;
            await _GroupStepProcessPermistionRepository.AddAsync(newGroupStepProcessPermistion).ConfigureAwait(false);
            await _GroupStepProcessPermistionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateGroupStepProcessPermistionCommandResponse>(newGroupStepProcessPermistion);
            return methodResult;
        }
    }
}