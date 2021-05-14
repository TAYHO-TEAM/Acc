using Acc.Cmd.Api.Application.Commands;
using Acc.Cmd.Domain.DomainObjects;
using AutoMapper;


namespace Acc.Cmd.Api.Infrastructure.Mappings
{
    public class PermistionsProfile : Profile 
    {
        public PermistionsProfile()
        {
            CreateMap<Permistions, PermistionsCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<Permistions, CreatePermistionsCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<Permistions, UpdatePermistionsCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
