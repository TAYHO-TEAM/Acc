using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class SysJobTableCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ISysJobTableRepository _sysJobTableRepository;

        public SysJobTableCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysJobTableRepository SysJobTableRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _sysJobTableRepository = SysJobTableRepository;
        }
    }
}
