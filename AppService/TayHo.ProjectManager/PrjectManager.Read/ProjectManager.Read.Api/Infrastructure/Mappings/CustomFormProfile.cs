using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;


namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class CustomFormProfile : Profile
    {
        public CustomFormProfile()
        {
            CreateMap<CustomFormDTO, CustomFormResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
            CreateMap<CustomFormDetailDTO, CustomFormDetailResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
            //CreateMap<CustomFormDetailBodyDTO, CustomFormBodyDetailResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
