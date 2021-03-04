using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_DuChiCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_DuChiRepository _NS_DuChiRepository;

        public NS_DuChiCommandHandler(IMapper mapper, INS_DuChiRepository NS_DuChiRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_DuChiRepository = NS_DuChiRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}