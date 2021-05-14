using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_LoaiCongViecCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_LoaiCongViecRepository _NS_LoaiCongViecRepository;

        public NS_LoaiCongViecCommandHandler(IMapper mapper, INS_LoaiCongViecRepository NS_LoaiCongViecRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_LoaiCongViecRepository = NS_LoaiCongViecRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}