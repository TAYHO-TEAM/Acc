using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanProjectCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IPlanProjectRepository _planProjectRepository;

        public PlanProjectCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IPlanProjectRepository PlanProjectRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _planProjectRepository = PlanProjectRepository;
        }
    }
}
