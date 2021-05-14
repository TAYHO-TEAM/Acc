using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using AutoMapper;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_NhomChiPhiProfile : Profile 
    {
        public NS_NhomChiPhiProfile()
        {
            CreateMap<NS_NhomChiPhi, CreateNS_NhomChiPhiCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_NhomChiPhi, UpdateNS_NhomChiPhiCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_NhomChiPhi, NS_NhomChiPhiCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
