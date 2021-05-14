using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class AccountInfoProfile: Profile
    {
        public AccountInfoProfile()
        {
            //CreateMap<AccountInfo, CreateAccountInfoCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            //CreateMap<AccountInfo, UpdateAccountInfoCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            //CreateMap<AccountInfo, AccountInfoCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
