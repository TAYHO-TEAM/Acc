using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_NhomChiPhiProfile : Profile
    {
        public NS_NhomChiPhiProfile()
        {
            CreateMap<NS_NhomChiPhiDTO, NS_NhomChiPhiResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
