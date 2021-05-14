using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class WorkItemsProfile : Profile
    {
        public WorkItemsProfile()
        { 
            CreateMap<WorkItemsDTO, WorkItemsResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
