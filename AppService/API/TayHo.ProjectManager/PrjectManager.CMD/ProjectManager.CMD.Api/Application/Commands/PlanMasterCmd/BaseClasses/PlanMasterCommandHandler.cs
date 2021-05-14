using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanMasterCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IPlanMasterRepository _planMasterRepository;

        public PlanMasterCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IPlanMasterRepository PlanMasterRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _planMasterRepository = PlanMasterRepository;
        }
    }
}
