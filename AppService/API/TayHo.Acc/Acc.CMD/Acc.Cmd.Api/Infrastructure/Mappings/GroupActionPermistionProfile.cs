using Acc.Cmd.Api.Application.Commands;
using Acc.Cmd.Domain.DomainObjects;
using AutoMapper;


namespace Acc.Cmd.Api.Infrastructure.Mappings
{
    public class GroupActionPermistionProfile : Profile 
    {
        public GroupActionPermistionProfile()
        {
            CreateMap<GroupActionPermistion, GroupActionPermistionCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<GroupActionPermistion, CreateGroupActionPermistionCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<GroupActionPermistion, UpdateGroupActionPermistionCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
