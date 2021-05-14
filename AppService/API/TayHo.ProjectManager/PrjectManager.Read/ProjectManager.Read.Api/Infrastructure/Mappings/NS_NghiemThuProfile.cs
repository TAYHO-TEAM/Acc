using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_NghiemThuProfile : Profile
    {
        public NS_NghiemThuProfile()
        {
            CreateMap<NS_NghiemThuDTO, NS_NghiemThuResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
            CreateMap<NS_NghiemThuDetailDTO, NS_NghiemThuDetailViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
