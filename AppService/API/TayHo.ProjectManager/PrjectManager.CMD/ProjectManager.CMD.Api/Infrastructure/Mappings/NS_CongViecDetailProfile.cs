using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_CongViecDetailProfile : Profile
    {
        public NS_CongViecDetailProfile()
        {
            CreateMap<NS_CongViecDetail, CreateNS_CongViecDetailCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_CongViecDetail, UpdateNS_CongViecDetailCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_CongViecDetail, NS_CongViecDetailCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
