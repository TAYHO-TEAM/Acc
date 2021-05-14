using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_CongViecDetailCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_CongViecDetailRepository _NS_CongViecDetailRepository;

        public NS_CongViecDetailCommandHandler(IMapper mapper, INS_CongViecDetailRepository NS_CongViecDetailRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_CongViecDetailRepository = NS_CongViecDetailRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}