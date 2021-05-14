using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupStepProcessPermistionCommandHandler :BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IGroupStepProcessPermistionRepository _GroupStepProcessPermistionRepository;

        public GroupStepProcessPermistionCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IGroupStepProcessPermistionRepository GroupStepProcessPermistionRepository) :  base (httpContextAccessor)
        {
            _mapper = mapper;
            _GroupStepProcessPermistionRepository = GroupStepProcessPermistionRepository;
        }
    }
}