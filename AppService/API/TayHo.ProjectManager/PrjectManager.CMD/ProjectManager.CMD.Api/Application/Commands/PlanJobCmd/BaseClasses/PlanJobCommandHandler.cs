using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanJobCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IPlanJobRepository _planJobRepository;

        public PlanJobCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IPlanJobRepository PlanJobRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _planJobRepository = PlanJobRepository;
        }
    }
}
