using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_LoaiCongViecProfile : Profile
    {
        public NS_LoaiCongViecProfile()
        {
            CreateMap<NS_LoaiCongViecDTO, NS_LoaiCongViecResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
