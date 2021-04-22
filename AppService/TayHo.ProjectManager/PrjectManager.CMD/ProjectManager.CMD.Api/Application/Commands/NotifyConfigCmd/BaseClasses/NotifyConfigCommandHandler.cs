using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NotifyConfigCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INotifyConfigRepository _notifyConfigRepository;

        public NotifyConfigCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, INotifyConfigRepository NotifyConfigRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _notifyConfigRepository = NotifyConfigRepository;
        }
    }
}
