using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class GroupStagesCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IGroupStagesRepository _GroupStagesRepository;

        public GroupStagesCommandHandler(IMapper mapper, IGroupStagesRepository GroupStagesRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _GroupStagesRepository = GroupStagesRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}