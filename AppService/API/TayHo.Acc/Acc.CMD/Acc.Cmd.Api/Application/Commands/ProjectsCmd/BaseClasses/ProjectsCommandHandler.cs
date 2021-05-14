using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class ProjectsCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IProjectsRepository _ProjectsRepository;

        public ProjectsCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IProjectsRepository ProjectsRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _ProjectsRepository = ProjectsRepository;
        }
    }
}