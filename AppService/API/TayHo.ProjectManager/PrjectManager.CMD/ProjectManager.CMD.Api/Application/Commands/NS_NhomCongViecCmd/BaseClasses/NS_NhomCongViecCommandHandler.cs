using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NhomCongViecCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_NhomCongViecRepository _NS_NhomCongViecRepository;

        public NS_NhomCongViecCommandHandler(IMapper mapper, INS_NhomCongViecRepository NS_NhomCongViecRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_NhomCongViecRepository = NS_NhomCongViecRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}