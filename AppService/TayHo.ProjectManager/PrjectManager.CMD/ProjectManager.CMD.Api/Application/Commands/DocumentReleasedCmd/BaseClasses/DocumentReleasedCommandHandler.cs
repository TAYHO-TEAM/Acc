using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DocumentReleasedCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IDocumentReleasedRepository _documentReleasedRepository;

        public DocumentReleasedCommandHandler(IMapper mapper, IDocumentReleasedRepository DocumentReleasedRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _documentReleasedRepository = DocumentReleasedRepository;
        }
    }
}