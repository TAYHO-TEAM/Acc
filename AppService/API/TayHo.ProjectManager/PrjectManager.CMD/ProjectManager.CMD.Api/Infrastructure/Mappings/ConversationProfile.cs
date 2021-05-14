using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using AutoMapper;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class ConversationProfile : Profile 
    {
        public ConversationProfile()
        {
            CreateMap<Conversation, CreateConversationCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<Conversation, UpdateConversationCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<Conversation, ConversationCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
