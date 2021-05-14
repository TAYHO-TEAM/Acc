using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class StagesProfile : Profile
    {
        public StagesProfile()
        { 
            CreateMap<StagesDTO, StagesResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
