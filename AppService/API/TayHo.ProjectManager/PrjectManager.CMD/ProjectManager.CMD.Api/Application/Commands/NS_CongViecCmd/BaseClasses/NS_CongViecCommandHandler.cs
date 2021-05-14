using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_CongViecCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_CongViecRepository _NS_CongViecRepository;

        public NS_CongViecCommandHandler(IMapper mapper, INS_CongViecRepository NS_CongViecRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_CongViecRepository = NS_CongViecRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}