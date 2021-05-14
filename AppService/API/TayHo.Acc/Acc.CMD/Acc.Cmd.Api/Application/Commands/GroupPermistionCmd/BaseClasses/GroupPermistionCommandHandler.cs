using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupPermistionCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IGroupPermistionRepository _GroupPermistionRepository;

        public GroupPermistionCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IGroupPermistionRepository GroupPermistionRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _GroupPermistionRepository = GroupPermistionRepository;
        }
    }
}