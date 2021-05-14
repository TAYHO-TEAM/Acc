using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_GoiThauCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_GoiThauRepository _NS_GoiThauRepository;

        public NS_GoiThauCommandHandler(IMapper mapper, INS_GoiThauRepository NS_GoiThauRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_GoiThauRepository = NS_GoiThauRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}