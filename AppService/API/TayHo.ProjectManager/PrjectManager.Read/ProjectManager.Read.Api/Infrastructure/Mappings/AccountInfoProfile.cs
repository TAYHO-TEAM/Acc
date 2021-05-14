using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class AccountInfoProfile : Profile
    {
        public AccountInfoProfile()
        {
            CreateMap<AccountInfoDTO, AccountInfoResponseViewModel>().ForMember(target => target.AccountId, m => m.MapFrom(source => source.AccountId));
            
        }
    }
}
