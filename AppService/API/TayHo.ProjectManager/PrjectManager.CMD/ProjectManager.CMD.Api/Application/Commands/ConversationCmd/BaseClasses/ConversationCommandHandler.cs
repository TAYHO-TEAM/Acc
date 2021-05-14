using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;
using ProjectManager.Common;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ConversationCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IConversationRepository _conversationRepository;
        protected const int _actionId = 55;
        protected const int _actionForAll = 85;
        protected const string _tableName = QuanLyDuAnConstants.Conversation_TABLENAME;

        public ConversationCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IConversationRepository ConversationRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _conversationRepository = ConversationRepository;
        }
    }
}
