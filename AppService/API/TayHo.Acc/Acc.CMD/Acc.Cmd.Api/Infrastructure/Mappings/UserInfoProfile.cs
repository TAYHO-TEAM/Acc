using Acc.Cmd.Api.Application.Commands;
using Acc.Cmd.Domain.DomainObjects;
using AutoMapper;


namespace Acc.Cmd.Api.Infrastructure.Mappings
{
    public class UserInfoProfile : Profile 
    {
        public UserInfoProfile()
        {
            CreateMap<UserInfo, CreateUserInfoCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<UserInfo, UpdateUserInfoCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<UserInfo, UserInfoCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
