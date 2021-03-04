using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NotifyTemplateCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INotifyTemplateRepository _notifyTemplateRepository;

        public NotifyTemplateCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, INotifyTemplateRepository NotifyTemplateRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _notifyTemplateRepository = NotifyTemplateRepository;
        }
    }
}
