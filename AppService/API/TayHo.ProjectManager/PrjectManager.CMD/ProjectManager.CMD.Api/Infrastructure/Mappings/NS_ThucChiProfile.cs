using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_ThucChiProfile : Profile
    {
        public NS_ThucChiProfile()
        {
            CreateMap<NS_ThucChi, CreateNS_ThucChiCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_ThucChi, UpdateNS_ThucChiCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_ThucChi, NS_ThucChiCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
