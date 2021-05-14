using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateGroupStagesCommandHandler : GroupStagesCommandHandler, IRequestHandler<CreateGroupStagesCommand, MethodResult<CreateGroupStagesCommandResponse>>
    {
        public CreateGroupStagesCommandHandler(IMapper mapper, IGroupStagesRepository GroupStagesRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, GroupStagesRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new GroupStages
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateGroupStagesCommandResponse>> Handle(CreateGroupStagesCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateGroupStagesCommandResponse>();
            var newGroupStages = new GroupStages(request.GroupId,
                                                request.StageId);
            newGroupStages.SetCreate(_user);
            newGroupStages.Status = request.Status.HasValue ? request.Status : newGroupStages.Status;
            newGroupStages.IsActive = request.IsActive.HasValue ? request.IsActive : newGroupStages.IsActive;
            newGroupStages.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newGroupStages.IsVisible;
            await _GroupStagesRepository.AddAsync(newGroupStages).ConfigureAwait(false);
            await _GroupStagesRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateGroupStagesCommandResponse>(newGroupStages);
            return methodResult;
        }
    }
}