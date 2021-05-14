using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NhomCongViecDetailCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_NhomCongViecDetailRepository _NS_NhomCongViecDetailRepository;

        public NS_NhomCongViecDetailCommandHandler(IMapper mapper, INS_NhomCongViecDetailRepository NS_NhomCongViecDetailRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_NhomCongViecDetailRepository = NS_NhomCongViecDetailRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}