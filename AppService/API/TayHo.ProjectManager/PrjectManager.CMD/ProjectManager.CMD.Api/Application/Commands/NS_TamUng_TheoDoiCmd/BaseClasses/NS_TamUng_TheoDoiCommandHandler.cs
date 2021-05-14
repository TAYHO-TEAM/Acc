using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_TamUng_TheoDoiCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_TamUng_TheoDoiRepository _NS_TamUng_TheoDoiRepository;

        public NS_TamUng_TheoDoiCommandHandler(IMapper mapper, INS_TamUng_TheoDoiRepository NS_TamUng_TheoDoiRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_TamUng_TheoDoiRepository = NS_TamUng_TheoDoiRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}