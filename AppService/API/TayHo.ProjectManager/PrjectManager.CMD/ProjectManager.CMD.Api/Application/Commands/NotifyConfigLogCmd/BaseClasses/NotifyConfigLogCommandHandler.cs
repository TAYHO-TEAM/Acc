using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NotifyConfigLogCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INotifyConfigLogRepository _notifyConfigLogRepository;

        public NotifyConfigLogCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, INotifyConfigLogRepository NotifyConfigLogRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _notifyConfigLogRepository = NotifyConfigLogRepository;
        }
    }
}
