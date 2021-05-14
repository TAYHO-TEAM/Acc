using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_NhomCongViecDetailProfile : Profile
    {
        public NS_NhomCongViecDetailProfile()
        {
            CreateMap<NS_NhomCongViecDetailDTO, NS_NhomCongViecDetailResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
