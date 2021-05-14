using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;


namespace Acc.Cmd.Api.Application.Commands
{
    public class UserInfoCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IUserInfoRepository _UserInfoRepository;

        public UserInfoCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IUserInfoRepository UserInfoRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _UserInfoRepository = UserInfoRepository;
        }
    }
}