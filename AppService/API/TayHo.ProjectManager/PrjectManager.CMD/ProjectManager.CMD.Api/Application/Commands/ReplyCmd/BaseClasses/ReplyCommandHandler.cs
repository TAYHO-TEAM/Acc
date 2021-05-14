using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ReplyCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IReplyRepository _ReplyRepository;

        public ReplyCommandHandler(IMapper mapper, IReplyRepository ReplyRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _ReplyRepository = ReplyRepository;
        }
    }
}