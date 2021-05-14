using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        { 
            CreateMap<AccountsDTO, AccountsResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
