using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class PermistionsCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IPermistionsRepository _PermistionsRepository;

        public PermistionsCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IPermistionsRepository PermistionsRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _PermistionsRepository = PermistionsRepository;
        }
    }
}