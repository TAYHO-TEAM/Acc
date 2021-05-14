using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class SysJobColumCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ISysJobColumRepository _sysJobColumRepository;

        public SysJobColumCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysJobColumRepository SysJobColumRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _sysJobColumRepository = SysJobColumRepository;
        }
    }
}
