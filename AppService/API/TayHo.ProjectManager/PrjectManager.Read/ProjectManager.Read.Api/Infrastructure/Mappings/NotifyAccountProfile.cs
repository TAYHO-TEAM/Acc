using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NotifyAccountProfile : Profile
    {
        public NotifyAccountProfile()
        {
            CreateMap<NotifyAccountDTO, NotifyAccountResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
