using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class SysJobParameterCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ISysJobParameterRepository _sysJobParameterRepository;

        public SysJobParameterCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysJobParameterRepository SysJobParameterRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _sysJobParameterRepository = SysJobParameterRepository;
        }
    }
}
