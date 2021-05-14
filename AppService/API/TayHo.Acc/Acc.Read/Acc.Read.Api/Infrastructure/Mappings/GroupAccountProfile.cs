using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class GroupAccountProfile : Profile
    {
        public GroupAccountProfile()
        { 
            CreateMap<GroupAccountDTO, GroupAccountResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
