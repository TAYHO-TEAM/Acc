using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_NhomCongViecProfile : Profile
    {
        public NS_NhomCongViecProfile()
        {
            CreateMap<NS_NhomCongViecDTO, NS_NhomCongViecResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
            CreateMap<NS_NhomCongViec_NhomCongViecDetailDTO, NS_NhomCongViec_NhomCongViecDetailResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
