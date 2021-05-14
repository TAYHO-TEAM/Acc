using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_HangMucDetailProfile : Profile
    {
        public NS_HangMucDetailProfile()
        {
            CreateMap<NS_HangMucDetailDTO, NS_HangMucDetailResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
