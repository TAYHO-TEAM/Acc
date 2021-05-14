using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_CongViecDetailProfile : Profile
    {
        public NS_CongViecDetailProfile()
        {
            CreateMap<NS_CongViecDetailDTO, NS_CongViecDetailResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
            CreateMap<NS_CongViecDetail_GoiThau_GiaiDoanDTO, NS_CongViecDetail_GoiThau_GiaiDoanResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
