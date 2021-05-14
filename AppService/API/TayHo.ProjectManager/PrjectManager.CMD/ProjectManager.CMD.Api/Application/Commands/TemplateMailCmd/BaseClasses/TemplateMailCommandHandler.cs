using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class TemplateMailCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ITemplateMailRepository _templateMailRepository;

        public TemplateMailCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ITemplateMailRepository TemplateMailRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _templateMailRepository = TemplateMailRepository;
        }
    }
}
