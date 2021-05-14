using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_Phat_TheoDoiCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_Phat_TheoDoiRepository _NS_Phat_TheoDoiRepository;

        public NS_Phat_TheoDoiCommandHandler(IMapper mapper, INS_Phat_TheoDoiRepository NS_Phat_TheoDoiRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_Phat_TheoDoiRepository = NS_Phat_TheoDoiRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}