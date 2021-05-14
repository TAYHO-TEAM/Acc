using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_ReasonProfile : Profile
    {
        public NS_ReasonProfile()
        {
            CreateMap<NS_Reason, CreateNS_ReasonCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_Reason, UpdateNS_ReasonCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_Reason, NS_ReasonCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
