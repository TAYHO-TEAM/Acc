using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class SysAutoSendMailCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ISysAutoSendMailRepository _sysAutoSendMailRepository;

        public SysAutoSendMailCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysAutoSendMailRepository SysAutoSendMailRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _sysAutoSendMailRepository = SysAutoSendMailRepository;
        }
    }
}
