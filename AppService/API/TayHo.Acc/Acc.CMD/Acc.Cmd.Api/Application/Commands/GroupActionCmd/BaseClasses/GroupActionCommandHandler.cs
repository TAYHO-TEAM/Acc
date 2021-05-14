using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupActionCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IGroupActionRepository _GroupActionRepository;

        public GroupActionCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IGroupActionRepository GroupActionRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _GroupActionRepository = GroupActionRepository;
        }
    }
}