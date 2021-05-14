using Acc.Cmd.Api.Application.Commands;
using Acc.Cmd.Domain.DomainObjects;
using AutoMapper;


namespace Acc.Cmd.Api.Infrastructure.Mappings
{
    public class GroupFunctionPermistionProfile : Profile 
    {
        public GroupFunctionPermistionProfile()
        {
            CreateMap<GroupFunctionPermistion, GroupFunctionPermistionCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<GroupFunctionPermistion, CreateGroupFunctionPermistionCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<GroupFunctionPermistion, UpdateGroupFunctionPermistionCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
