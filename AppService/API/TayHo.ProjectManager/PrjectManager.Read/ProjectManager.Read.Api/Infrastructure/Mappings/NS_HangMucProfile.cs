using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_HangMucProfile : Profile
    {
        public NS_HangMucProfile()
        {
            CreateMap<NS_HangMucDTO, NS_HangMucResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
            CreateMap<NS_HangMuc_HangMucDetailDTO, NS_HangMuc_HangMucDetailResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
