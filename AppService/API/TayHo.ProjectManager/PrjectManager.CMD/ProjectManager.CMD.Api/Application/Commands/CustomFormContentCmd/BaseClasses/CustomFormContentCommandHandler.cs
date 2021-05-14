using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CustomFormContentCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ICustomFormContentRepository _customFormContentRepository;

        public CustomFormContentCommandHandler(IMapper mapper, ICustomFormContentRepository CustomFormContentRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _customFormContentRepository = CustomFormContentRepository;
        }
    }
}