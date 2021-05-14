using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class ActionsCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IActionsRepository _actionsRepository;

        public ActionsCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IActionsRepository ActionsRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _actionsRepository = ActionsRepository;
        }
    }
}