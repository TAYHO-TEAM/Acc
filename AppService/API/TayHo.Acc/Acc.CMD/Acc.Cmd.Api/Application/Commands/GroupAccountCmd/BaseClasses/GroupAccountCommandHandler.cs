using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupAccountCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IGroupAccountRepository _GroupAccountRepository;

        public GroupAccountCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IGroupAccountRepository GroupAccountRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _GroupAccountRepository = GroupAccountRepository;
        }
    }
}