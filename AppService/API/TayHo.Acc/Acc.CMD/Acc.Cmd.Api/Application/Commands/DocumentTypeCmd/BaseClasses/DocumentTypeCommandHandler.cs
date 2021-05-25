using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class DocumentTypeCommandHandler :BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IDocumentTypeRepository _DocumentTypeRepository;

        public DocumentTypeCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IDocumentTypeRepository DocumentTypeRepository) :  base (httpContextAccessor)
        {
            _mapper = mapper;
            _DocumentTypeRepository = DocumentTypeRepository;
        }
    }
}