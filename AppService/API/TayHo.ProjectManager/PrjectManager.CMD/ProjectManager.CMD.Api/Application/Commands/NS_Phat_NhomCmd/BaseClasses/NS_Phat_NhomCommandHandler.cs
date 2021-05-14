using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_Phat_NhomCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_Phat_NhomRepository _NS_Phat_NhomRepository;

        public NS_Phat_NhomCommandHandler(IMapper mapper, INS_Phat_NhomRepository NS_Phat_NhomRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_Phat_NhomRepository = NS_Phat_NhomRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}