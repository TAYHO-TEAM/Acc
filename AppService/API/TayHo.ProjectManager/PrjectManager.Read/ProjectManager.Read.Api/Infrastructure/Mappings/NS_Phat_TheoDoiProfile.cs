using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_Phat_TheoDoiProfile : Profile
    {
        public NS_Phat_TheoDoiProfile()
        {
            CreateMap<NS_Phat_TheoDoiDTO, NS_Phat_TheoDoiResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
