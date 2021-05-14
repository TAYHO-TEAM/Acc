using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_GiaiDoanCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly INS_GiaiDoanRepository _NS_GiaiDoanRepository;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public NS_GiaiDoanCommandHandler(IMapper mapper, INS_GiaiDoanRepository NS_GiaiDoanRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_GiaiDoanRepository = NS_GiaiDoanRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}