using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class RelationTableCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IRelationTableRepository _RelationTableRepository;

        public RelationTableCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IRelationTableRepository RelationTableRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _RelationTableRepository = RelationTableRepository;
        }
    }
}