using Acc.Cmd.Api.Application.Commands;
using Acc.Cmd.Domain.DomainObjects;
using AutoMapper;


namespace Acc.Cmd.Api.Infrastructure.Mappings
{
    public class RelationTableProfile : Profile 
    {
        public RelationTableProfile()
        {
            CreateMap<RelationTable, RelationTableCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<RelationTable, CreateRelationTableCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<RelationTable, UpdateRelationTableCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
