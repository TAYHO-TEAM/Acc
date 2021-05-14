using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class SysJobCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ISysJobRepository _sysJobRepository;

        public SysJobCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysJobRepository SysJobRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _sysJobRepository = SysJobRepository;
        }
    }
}
