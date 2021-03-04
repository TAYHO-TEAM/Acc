using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanScheduleCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IPlanScheduleRepository _planScheduleRepository;

        public PlanScheduleCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IPlanScheduleRepository PlanScheduleRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _planScheduleRepository = PlanScheduleRepository;
        }
    }
}
