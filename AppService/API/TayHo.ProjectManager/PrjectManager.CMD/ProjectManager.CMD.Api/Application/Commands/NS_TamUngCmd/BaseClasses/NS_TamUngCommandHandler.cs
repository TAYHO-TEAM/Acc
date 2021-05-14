using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_TamUngCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_TamUngRepository _NS_TamUngRepository;

        public NS_TamUngCommandHandler(IMapper mapper, INS_TamUngRepository NS_TamUngRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_TamUngRepository = NS_TamUngRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}