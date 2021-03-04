using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class LogEventCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ILogEventRepository _LogEventRepository;

        public LogEventCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, ILogEventRepository LogEventRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _LogEventRepository = LogEventRepository;
        }
    }
}