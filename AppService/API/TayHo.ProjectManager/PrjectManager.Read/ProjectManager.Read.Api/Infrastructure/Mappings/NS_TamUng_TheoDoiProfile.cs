using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_TamUng_TheoDoiProfile : Profile
    {
        public NS_TamUng_TheoDoiProfile()
        {
            CreateMap<NS_TamUng_TheoDoiDTO, NS_TamUng_TheoDoiResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
