using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanAccountCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IPlanAccountRepository _planAccountRepository;

        public PlanAccountCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IPlanAccountRepository PlanAccountRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _planAccountRepository = PlanAccountRepository;
        }
    }
}
