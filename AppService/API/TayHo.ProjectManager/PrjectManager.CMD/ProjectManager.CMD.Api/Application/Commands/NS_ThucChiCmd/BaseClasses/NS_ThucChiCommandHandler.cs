using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_ThucChiCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_ThucChiRepository _NS_ThucChiRepository;

        public NS_ThucChiCommandHandler(IMapper mapper, INS_ThucChiRepository NS_ThucChiRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_ThucChiRepository = NS_ThucChiRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}