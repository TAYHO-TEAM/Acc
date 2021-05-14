using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class GroupStagesProfile : Profile
    {
        public GroupStagesProfile()
        { 
            CreateMap<GroupStagesDTO, GroupStagesResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
