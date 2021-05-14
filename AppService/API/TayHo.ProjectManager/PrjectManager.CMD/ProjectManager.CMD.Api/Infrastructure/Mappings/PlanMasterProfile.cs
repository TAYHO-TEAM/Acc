using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using AutoMapper;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class PlanMasterProfile : Profile 
    {
        public PlanMasterProfile()
        {
            CreateMap<PlanMaster, CreatePlanMasterCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<PlanMaster, CreateFormPlanMasterCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<PlanMaster, CreateFormProgressPlanMasterCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<PlanMaster, UpdatePlanMasterCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<PlanMaster, PlanMasterCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            
        }
    }
}
