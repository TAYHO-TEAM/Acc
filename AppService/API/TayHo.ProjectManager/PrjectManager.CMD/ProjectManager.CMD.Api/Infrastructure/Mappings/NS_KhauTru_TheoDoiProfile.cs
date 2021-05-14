using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_KhauTru_TheoDoiProfile : Profile
    {
        public NS_KhauTru_TheoDoiProfile()
        {
            CreateMap<NS_KhauTru_TheoDoi, CreateNS_KhauTru_TheoDoiCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_KhauTru_TheoDoi, UpdateNS_KhauTru_TheoDoiCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_KhauTru_TheoDoi, NS_KhauTru_TheoDoiCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
