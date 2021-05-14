using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupStagesCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IGroupStagesRepository _GroupStagesRepository;

        public GroupStagesCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IGroupStagesRepository GroupStagesRepository) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _GroupStagesRepository = GroupStagesRepository;
        }
    }
}