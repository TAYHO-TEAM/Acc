using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ResponseRegistCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IResponseRegistRepository _ResponseRegistRepository;

        public ResponseRegistCommandHandler(IMapper mapper, IResponseRegistRepository ResponseRegistRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _ResponseRegistRepository = ResponseRegistRepository;
        }
    }
}