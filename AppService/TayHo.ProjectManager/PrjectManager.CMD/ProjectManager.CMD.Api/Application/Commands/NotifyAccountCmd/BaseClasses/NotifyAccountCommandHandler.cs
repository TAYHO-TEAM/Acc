using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NotifyAccountCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INotifyAccountRepository _notifyAccountRepository;

        public NotifyAccountCommandHandler(IMapper mapper, INotifyAccountRepository NotifyAccountRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _notifyAccountRepository = NotifyAccountRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}