using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanRegisterCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IPlanRegisterRepository _planRegisterRepository;

        public PlanRegisterCommandHandler(IMapper mapper, IPlanRegisterRepository PlanRegisterRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _planRegisterRepository = PlanRegisterRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}