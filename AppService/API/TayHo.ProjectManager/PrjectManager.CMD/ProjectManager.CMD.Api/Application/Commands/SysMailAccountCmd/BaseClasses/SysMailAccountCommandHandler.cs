using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class SysMailAccountCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ISysMailAccountRepository _sysMailAccountRepository;

        public SysMailAccountCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysMailAccountRepository SysMailAccountRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _sysMailAccountRepository = SysMailAccountRepository;
        }
    }
}
