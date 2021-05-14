using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class PlanRegisterProfile : Profile
    {
        public PlanRegisterProfile()
        {
            CreateMap<PlanRegisterDTO, PlanRegisterResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
