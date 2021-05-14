using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_KhauTruProfile : Profile
    {
        public NS_KhauTruProfile()
        {
            CreateMap<NS_KhauTru, CreateNS_KhauTruCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_KhauTru, UpdateNS_KhauTruCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_KhauTru, NS_KhauTruCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
