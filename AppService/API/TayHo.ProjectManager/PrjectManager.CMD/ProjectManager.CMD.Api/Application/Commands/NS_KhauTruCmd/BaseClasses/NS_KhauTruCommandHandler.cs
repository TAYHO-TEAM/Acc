using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_KhauTruCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_KhauTruRepository _NS_KhauTruRepository;

        public NS_KhauTruCommandHandler(IMapper mapper, INS_KhauTruRepository NS_KhauTruRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_KhauTruRepository = NS_KhauTruRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}