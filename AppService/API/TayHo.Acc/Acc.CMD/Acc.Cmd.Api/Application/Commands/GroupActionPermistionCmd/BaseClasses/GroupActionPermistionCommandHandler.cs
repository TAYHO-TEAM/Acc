using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupActionPermistionCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IGroupActionPermistionRepository _GroupActionPermistionRepository;

        public GroupActionPermistionCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IGroupActionPermistionRepository GroupActionPermistionRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _GroupActionPermistionRepository = GroupActionPermistionRepository;
        }
    }
}