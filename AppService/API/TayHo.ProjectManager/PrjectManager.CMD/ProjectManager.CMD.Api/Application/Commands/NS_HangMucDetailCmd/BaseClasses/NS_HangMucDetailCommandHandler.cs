using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_HangMucDetailCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_HangMucDetailRepository _NS_HangMucDetailRepository;

        public NS_HangMucDetailCommandHandler(IMapper mapper, INS_HangMucDetailRepository NS_HangMucDetailRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_HangMucDetailRepository = NS_HangMucDetailRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}