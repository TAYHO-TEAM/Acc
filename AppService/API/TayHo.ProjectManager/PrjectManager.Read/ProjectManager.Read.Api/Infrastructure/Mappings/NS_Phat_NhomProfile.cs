using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_Phat_NhomProfile : Profile
    {
        public NS_Phat_NhomProfile()
        {
            CreateMap<NS_Phat_NhomDTO, NS_Phat_NhomResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
