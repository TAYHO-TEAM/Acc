using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupActionPermistionCommandHandler : GroupActionPermistionCommandHandler, IRequestHandler<CreateGroupActionPermistionCommand, MethodResult<CreateGroupActionPermistionCommandResponse>>
    {
        public CreateGroupActionPermistionCommandHandler(IMapper mapper, IGroupActionPermistionRepository GroupActionPermistionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupActionPermistionRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new GroupActionPermistion
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateGroupActionPermistionCommandResponse>> Handle(CreateGroupActionPermistionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateGroupActionPermistionCommandResponse>();
            var newGroupActionPermistion = new GroupActionPermistion(request.GroupId,
                                                                    request.ActionId,
                                                                    request.PermistionId);
            newGroupActionPermistion.SetCreate(_user);
            newGroupActionPermistion.Status = request.Status.HasValue ? request.Status : newGroupActionPermistion.Status;
            newGroupActionPermistion.IsActive = request.IsActive.HasValue ? request.IsActive : newGroupActionPermistion.IsActive;
            newGroupActionPermistion.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newGroupActionPermistion.IsVisible;
            await _GroupActionPermistionRepository.AddAsync(newGroupActionPermistion).ConfigureAwait(false);
            await _GroupActionPermistionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateGroupActionPermistionCommandResponse>(newGroupActionPermistion);
            return methodResult;
        }
    }
}