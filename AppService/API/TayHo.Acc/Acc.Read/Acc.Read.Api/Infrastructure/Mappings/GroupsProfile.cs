using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class GroupsProfile : Profile
    {
        public GroupsProfile()
        { 
            CreateMap<GroupsDTO, GroupsResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
