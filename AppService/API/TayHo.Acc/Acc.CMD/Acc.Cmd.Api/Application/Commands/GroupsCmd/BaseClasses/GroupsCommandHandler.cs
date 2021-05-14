using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupsCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IGroupsRepository _GroupsRepository;

        public GroupsCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IGroupsRepository GroupsRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _GroupsRepository = GroupsRepository;
        }
    }
}