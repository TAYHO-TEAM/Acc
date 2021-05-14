using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CustomCellContentCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ICustomCellContentRepository _customCellContentRepository;

        public CustomCellContentCommandHandler(IMapper mapper, ICustomCellContentRepository CustomCellContentRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _customCellContentRepository = CustomCellContentRepository;
        }
    }
}