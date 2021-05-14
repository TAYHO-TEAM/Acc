using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class GroupPermistionProfile : Profile
    {
        public GroupPermistionProfile()
        { 
            CreateMap<GroupPermistionDTO, GroupPermistionResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
