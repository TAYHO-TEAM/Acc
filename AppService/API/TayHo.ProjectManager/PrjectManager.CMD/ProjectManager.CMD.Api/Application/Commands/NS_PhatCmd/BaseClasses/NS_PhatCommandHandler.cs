using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_PhatCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_PhatRepository _NS_PhatRepository;

        public NS_PhatCommandHandler(IMapper mapper, INS_PhatRepository NS_PhatRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_PhatRepository = NS_PhatRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}