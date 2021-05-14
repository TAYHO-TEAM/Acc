using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_KhauTruProfile : Profile
    {
        public NS_KhauTruProfile()
        {
            CreateMap<NS_KhauTruDTO, NS_KhauTruResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
