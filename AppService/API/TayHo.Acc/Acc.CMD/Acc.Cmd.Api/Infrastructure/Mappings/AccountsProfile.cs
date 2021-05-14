using Acc.Cmd.Api.Application.Commands;
using Acc.Cmd.Api.ViewModels;
using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.DTOs;
using AutoMapper;


namespace Acc.Cmd.Api.Infrastructure.Mappings
{
    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        {
            CreateMap<Accounts, AccountsCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<Accounts, CreateAccountsCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<Accounts, UpdateAccountsCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            //CreateMap<LoginRequestViewModel,LoginDTO>().ForMember(x => x.UserName, opt => opt.MapFrom(t => t.UserName));
        }
    }
}
