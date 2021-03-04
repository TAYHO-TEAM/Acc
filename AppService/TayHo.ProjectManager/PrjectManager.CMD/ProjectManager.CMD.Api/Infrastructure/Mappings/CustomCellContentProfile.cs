using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using System.Collections.Generic;

namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class CustomCellContentProfile: Profile
    {
        public CustomCellContentProfile()
        {
            CreateMap<CustomCellContent, CreateFormCustomCellContentCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<CustomCellContent, CreateCustomCellContentCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<CustomCellContent, UpdateCustomCellContentCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<CustomCellContent, CustomCellContentCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
