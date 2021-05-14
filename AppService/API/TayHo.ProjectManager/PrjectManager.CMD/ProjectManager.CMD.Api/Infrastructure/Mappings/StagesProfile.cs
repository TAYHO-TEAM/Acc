using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class StagesProfile: Profile
    {
        public StagesProfile()
        {
            CreateMap<Stages, CreateStagesCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<Stages, UpdateStagesCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<Stages, StagesCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
