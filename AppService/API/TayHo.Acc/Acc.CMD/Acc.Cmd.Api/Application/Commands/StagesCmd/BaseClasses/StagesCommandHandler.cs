using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class StagesCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IStagesRepository _StagesRepository;

        public StagesCommandHandler(IMapper mapper, IStagesRepository StagesRepository)
        {
            _mapper = mapper;
            _StagesRepository = StagesRepository;
        }
    }
}