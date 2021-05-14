using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class PlanJobProfile : Profile
    {
        public PlanJobProfile()
        {
            CreateMap<PlanJobDTO, PlanJobResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
            CreateMap<PlanJobAccountPermitDTO, PlanJobAccountPermitResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
