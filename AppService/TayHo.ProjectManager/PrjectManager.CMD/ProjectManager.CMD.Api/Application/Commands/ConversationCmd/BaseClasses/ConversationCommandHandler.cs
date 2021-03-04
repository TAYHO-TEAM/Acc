using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ConversationCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IConversationRepository _conversationRepository;

        public ConversationCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IConversationRepository ConversationRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _conversationRepository = ConversationRepository;
        }
    }
}
