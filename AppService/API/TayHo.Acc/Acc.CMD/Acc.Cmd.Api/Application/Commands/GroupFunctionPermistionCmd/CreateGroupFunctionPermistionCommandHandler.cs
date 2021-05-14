using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupFunctionPermistionCommandHandler : GroupFunctionPermistionCommandHandler, IRequestHandler<CreateGroupFunctionPermistionCommand, MethodResult<CreateGroupFunctionPermistionCommandResponse>>
    {
        public CreateGroupFunctionPermistionCommandHandler(IMapper mapper, IGroupFunctionPermistionRepository GroupFunctionPermistionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupFunctionPermistionRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new GroupFunctionPermistion
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateGroupFunctionPermistionCommandResponse>> Handle(CreateGroupFunctionPermistionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateGroupFunctionPermistionCommandResponse>();
            var newGroupFunctionPermistion = new GroupFunctionPermistion(request.GroupId,
                                                                            request.FunctionId,
                                                                            request.PermistionId);
            newGroupFunctionPermistion.SetCreate(_user);
            newGroupFunctionPermistion.Status = request.Status.HasValue ? request.Status : newGroupFunctionPermistion.Status;
            newGroupFunctionPermistion.IsActive = request.IsActive.HasValue ? request.IsActive : newGroupFunctionPermistion.IsActive;
            newGroupFunctionPermistion.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newGroupFunctionPermistion.IsVisible;
            await _GroupFunctionPermistionRepository.AddAsync(newGroupFunctionPermistion).ConfigureAwait(false);
            await _GroupFunctionPermistionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateGroupFunctionPermistionCommandResponse>(newGroupFunctionPermistion);
            return methodResult;
        }
    }
}