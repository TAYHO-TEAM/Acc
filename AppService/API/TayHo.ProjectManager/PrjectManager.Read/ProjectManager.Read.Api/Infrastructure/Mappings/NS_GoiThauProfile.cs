using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_GoiThauProfile : Profile
    {
        public NS_GoiThauProfile()
        {
            CreateMap<NS_GoiThauDTO, NS_GoiThauResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
