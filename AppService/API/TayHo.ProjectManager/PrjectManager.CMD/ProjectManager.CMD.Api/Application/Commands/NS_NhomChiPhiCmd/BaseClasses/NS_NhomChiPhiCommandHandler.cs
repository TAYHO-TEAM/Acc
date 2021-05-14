using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NhomChiPhiCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_NhomChiPhiRepository _NS_NhomChiPhiRepository;

        public NS_NhomChiPhiCommandHandler(IMapper mapper, INS_NhomChiPhiRepository NS_NhomChiPhiRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_NhomChiPhiRepository = NS_NhomChiPhiRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}