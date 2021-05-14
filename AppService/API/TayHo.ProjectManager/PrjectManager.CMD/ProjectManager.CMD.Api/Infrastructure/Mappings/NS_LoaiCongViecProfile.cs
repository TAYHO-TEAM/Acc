using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using AutoMapper;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_LoaiCongViecProfile : Profile 
    {
        public NS_LoaiCongViecProfile()
        {
            CreateMap<NS_LoaiCongViec, CreateNS_LoaiCongViecCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_LoaiCongViec, UpdateNS_LoaiCongViecCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_LoaiCongViec, NS_LoaiCongViecCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
