using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_TamUngProfile : Profile
    {
        public NS_TamUngProfile()
        {
            CreateMap<NS_TamUngDTO, NS_TamUngResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
