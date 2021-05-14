using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
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