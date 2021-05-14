using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NotifyCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INotifyRepository _notifyRepository;

        public NotifyCommandHandler(IMapper mapper, INotifyRepository NotifyRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _notifyRepository = NotifyRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}