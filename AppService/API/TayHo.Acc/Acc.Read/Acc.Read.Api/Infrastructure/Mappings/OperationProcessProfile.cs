using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class OperationProcessProfile : Profile
    {
        public OperationProcessProfile()
        { 
            CreateMap<OperationProcessDTO, OperationProcessResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
