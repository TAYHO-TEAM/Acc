using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_ReasonCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_ReasonRepository _NS_ReasonRepository;

        public NS_ReasonCommandHandler(IMapper mapper, INS_ReasonRepository NS_ReasonRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_ReasonRepository = NS_ReasonRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}