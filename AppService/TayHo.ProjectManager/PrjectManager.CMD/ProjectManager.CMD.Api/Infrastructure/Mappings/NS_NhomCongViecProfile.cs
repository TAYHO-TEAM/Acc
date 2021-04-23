using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using AutoMapper;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_NhomCongViecProfile : Profile 
    {
        public NS_NhomCongViecProfile()
        {
            CreateMap<NS_NhomCongViec, CreateNS_NhomCongViecCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_NhomCongViec, UpdateNS_NhomCongViecCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_NhomCongViec, NS_NhomCongViecCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
