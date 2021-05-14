using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_GiaiDoanProfile : Profile
    {
        public NS_GiaiDoanProfile()
        {
            CreateMap<NS_GiaiDoanDTO, NS_GiaiDoanResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
