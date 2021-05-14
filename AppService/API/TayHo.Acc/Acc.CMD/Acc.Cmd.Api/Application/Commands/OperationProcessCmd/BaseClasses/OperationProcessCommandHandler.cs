using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class OperationProcessCommandHandler :BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IOperationProcessRepository _OperationProcessRepository;

        public OperationProcessCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IOperationProcessRepository OperationProcessRepository) :  base (httpContextAccessor)
        {
            _mapper = mapper;
            _OperationProcessRepository = OperationProcessRepository;
        }
    }
}