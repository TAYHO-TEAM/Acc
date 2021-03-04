using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CustomFormBodyCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ICustomFormBodyRepository _customFormBodyRepository;

        public CustomFormBodyCommandHandler(IMapper mapper, ICustomFormBodyRepository CustomFormBodyRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _customFormBodyRepository = CustomFormBodyRepository;
        }
    }
}