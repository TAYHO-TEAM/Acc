using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class FilesAttachmentCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IFilesAttachmentRepository _FilesAttachmentRepository; 
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public FilesAttachmentCommandHandler(IMapper mapper, IFilesAttachmentRepository FilesAttachmentRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _FilesAttachmentRepository = FilesAttachmentRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}