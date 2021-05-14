using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace Acc.Cmd.Api.Application.Commands
{
    public class AccountsCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IAccountsRepository _accountsRepository;

        public AccountsCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IAccountsRepository AccountsRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _accountsRepository = AccountsRepository;
          
        }
    }
}