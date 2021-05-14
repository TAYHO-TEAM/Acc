using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class FunctionsCommandHandler: BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IFunctionsRepository _FunctionsRepository;

        public FunctionsCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IFunctionsRepository FunctionsRepository) :  base (httpContextAccessor)
        {
            _mapper = mapper;
            _FunctionsRepository = FunctionsRepository;
        }
    }
}