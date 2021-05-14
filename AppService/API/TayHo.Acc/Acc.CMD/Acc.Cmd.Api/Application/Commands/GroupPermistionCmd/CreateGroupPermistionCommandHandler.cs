using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupPermistionCommandHandler : GroupPermistionCommandHandler, IRequestHandler<CreateGroupPermistionCommand, MethodResult<CreateGroupPermistionCommandResponse>>
    {
        public CreateGroupPermistionCommandHandler(IMapper mapper, IGroupPermistionRepository GroupPermistionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupPermistionRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new GroupPermistion
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateGroupPermistionCommandResponse>> Handle(CreateGroupPermistionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateGroupPermistionCommandResponse>();
            var newGroupPermistion = new GroupPermistion(request.PermistionId,
                                                    request.GroupId);
            newGroupPermistion.SetCreate(_user);
            newGroupPermistion.Status = request.Status.HasValue ? request.Status : newGroupPermistion.Status;
            newGroupPermistion.IsActive = request.IsActive.HasValue ? request.IsActive : newGroupPermistion.IsActive;
            newGroupPermistion.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newGroupPermistion.IsVisible;
            await _GroupPermistionRepository.AddAsync(newGroupPermistion).ConfigureAwait(false);
            await _GroupPermistionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateGroupPermistionCommandResponse>(newGroupPermistion);
            return methodResult;
        }
    }
}