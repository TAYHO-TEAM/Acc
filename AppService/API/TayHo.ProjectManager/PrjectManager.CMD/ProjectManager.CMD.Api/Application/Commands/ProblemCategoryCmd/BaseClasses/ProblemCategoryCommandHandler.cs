using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ProblemCategoryCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IProblemCategoryRepository _ProblemCategoryRepository;

        public ProblemCategoryCommandHandler(IMapper mapper, IProblemCategoryRepository ProblemCategoryRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _ProblemCategoryRepository = ProblemCategoryRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}