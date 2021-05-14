using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DocumentTypeCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IDocumentTypeRepository _DocumentTypeRepository;

        public DocumentTypeCommandHandler(IMapper mapper, IDocumentTypeRepository DocumentTypeRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _DocumentTypeRepository = DocumentTypeRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}