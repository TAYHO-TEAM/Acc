using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_KhauTru_TheoDoiProfile : Profile
    {
        public NS_KhauTru_TheoDoiProfile()
        {
            CreateMap<NS_KhauTru_TheoDoiDTO, NS_KhauTru_TheoDoiResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
