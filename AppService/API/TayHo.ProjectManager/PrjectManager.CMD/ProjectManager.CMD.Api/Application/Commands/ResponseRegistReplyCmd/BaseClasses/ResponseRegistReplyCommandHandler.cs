using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ResponseRegistReplyCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IResponseRegistReplyRepository _ResponseRegistReplyRepository;

        public ResponseRegistReplyCommandHandler(IMapper mapper, IResponseRegistReplyRepository ResponseRegistReplyRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _ResponseRegistReplyRepository = ResponseRegistReplyRepository;
        }
    }
}