using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using AutoMapper;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_NhomCongViecDetailProfile : Profile 
    {
        public NS_NhomCongViecDetailProfile()
        {
            CreateMap<NS_NhomCongViecDetail, CreateNS_NhomCongViecDetailCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_NhomCongViecDetail, UpdateNS_NhomCongViecDetailCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_NhomCongViecDetail, NS_NhomCongViecDetailCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
