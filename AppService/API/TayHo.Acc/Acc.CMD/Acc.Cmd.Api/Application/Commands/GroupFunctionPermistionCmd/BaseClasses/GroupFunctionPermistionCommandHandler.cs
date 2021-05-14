using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupFunctionPermistionCommandHandler: BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IGroupFunctionPermistionRepository _GroupFunctionPermistionRepository;

        public GroupFunctionPermistionCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IGroupFunctionPermistionRepository GroupFunctionPermistionRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _GroupFunctionPermistionRepository = GroupFunctionPermistionRepository;
        }
    }
}