using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DocumentReleasedLogCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IDocumentReleasedLogRepository _DocumentReleasedLogRepository;

        public DocumentReleasedLogCommandHandler(IMapper mapper, IDocumentReleasedLogRepository DocumentReleasedLogRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _DocumentReleasedLogRepository = DocumentReleasedLogRepository;
        }
    }
}