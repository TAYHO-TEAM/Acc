using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class StepsProcessCommandHandler :BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IStepsProcessRepository _StepsProcessRepository;

        public StepsProcessCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IStepsProcessRepository StepsProcessRepository) :  base (httpContextAccessor)
        {
            _mapper = mapper;
            _StepsProcessRepository = StepsProcessRepository;
        }
    }
}