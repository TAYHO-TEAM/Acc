using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class CategorysCommandHandler:BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ICategorysRepository _CategorysRepository;

        public CategorysCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, ICategorysRepository CategorysRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _CategorysRepository = CategorysRepository;
        }
    }
}