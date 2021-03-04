using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_ThucChiProfile : Profile
    {
        public NS_ThucChiProfile()
        {
            CreateMap<NS_ThucChiDTO, NS_ThucChiResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
