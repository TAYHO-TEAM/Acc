using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class CustomColumProfile: Profile
    {
        public CustomColumProfile()
        {
            CreateMap<CustomColum, CreateCustomColumCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<CustomColum, UpdateCustomColumCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<CustomColum, CustomColumCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
