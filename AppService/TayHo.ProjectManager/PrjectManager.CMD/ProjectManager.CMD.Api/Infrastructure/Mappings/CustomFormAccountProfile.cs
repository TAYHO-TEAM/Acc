using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using AutoMapper;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class CustomFormAccountProfile : Profile 
    {
        public CustomFormAccountProfile()
        {
            CreateMap<CustomFormAccount, CreateCustomFormAccountCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<CustomFormAccount, UpdateCustomFormAccountCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<CustomFormAccount, CustomFormAccountCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
