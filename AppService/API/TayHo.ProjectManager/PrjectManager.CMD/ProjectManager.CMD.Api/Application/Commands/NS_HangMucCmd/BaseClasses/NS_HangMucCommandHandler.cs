using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_HangMucCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_HangMucRepository _NS_HangMucRepository;

        public NS_HangMucCommandHandler(IMapper mapper, INS_HangMucRepository NS_HangMucRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_HangMucRepository = NS_HangMucRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}