using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using AutoMapper;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_GiaiDoanProfile : Profile 
    {
        public NS_GiaiDoanProfile()
        {
            CreateMap<NS_GiaiDoan, CreateNS_GiaiDoanCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_GiaiDoan, UpdateNS_GiaiDoanCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_GiaiDoan, NS_GiaiDoanCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
