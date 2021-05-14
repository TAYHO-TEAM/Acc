using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class GroupFunctionPermistionProfile : Profile
    {
        public GroupFunctionPermistionProfile()
        { 
            CreateMap<GroupFunctionPermistionDTO, GroupFunctionPermistionResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
