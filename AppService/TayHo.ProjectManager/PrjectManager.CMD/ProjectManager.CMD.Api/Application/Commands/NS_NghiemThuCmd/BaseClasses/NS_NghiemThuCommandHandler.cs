using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NghiemThuCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_NghiemThuRepository _nS_NghiemThuRepository;

        public NS_NghiemThuCommandHandler(IMapper mapper, INS_NghiemThuRepository NS_NghiemThuRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _nS_NghiemThuRepository = NS_NghiemThuRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}