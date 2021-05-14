using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_KhauTru_TheoDoiCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_KhauTru_TheoDoiRepository _NS_KhauTru_TheoDoiRepository;

        public NS_KhauTru_TheoDoiCommandHandler(IMapper mapper, INS_KhauTru_TheoDoiRepository NS_KhauTru_TheoDoiRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_KhauTru_TheoDoiRepository = NS_KhauTru_TheoDoiRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}