using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class GroupStepProcessPermistionProfile : Profile
    {
        public GroupStepProcessPermistionProfile()
        { 
            CreateMap<GroupStepProcessPermistionDTO, GroupStepProcessPermistionResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
