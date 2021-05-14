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
    public class CreateGroupsCommandHandler : GroupsCommandHandler, IRequestHandler<CreateGroupsCommand, MethodResult<CreateGroupsCommandResponse>>
    {
        public CreateGroupsCommandHandler(IMapper mapper, IGroupsRepository GroupsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupsRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new Groups
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateGroupsCommandResponse>> Handle(CreateGroupsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateGroupsCommandResponse>();
            var newGroups = new Groups(request.Title,
                                        request.Descriptions,
                                        request.Type);
            newGroups.SetCreate(_user);
            newGroups.Status = request.Status.HasValue ? request.Status : newGroups.Status;
            newGroups.IsActive = request.IsActive.HasValue ? request.IsActive : newGroups.IsActive;
            newGroups.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newGroups.IsVisible;
            await _GroupsRepository.AddAsync(newGroups).ConfigureAwait(false);
            await _GroupsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateGroupsCommandResponse>(newGroups);
            return methodResult;
        }
    }
}