using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DocumentReleasedAccountCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IDocumentReleasedAccountRepository _documentReleasedAccountRepository;

        public DocumentReleasedAccountCommandHandler(IMapper mapper, IDocumentReleasedAccountRepository DocumentReleasedAccountRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _documentReleasedAccountRepository = DocumentReleasedAccountRepository;
        }
    }
}