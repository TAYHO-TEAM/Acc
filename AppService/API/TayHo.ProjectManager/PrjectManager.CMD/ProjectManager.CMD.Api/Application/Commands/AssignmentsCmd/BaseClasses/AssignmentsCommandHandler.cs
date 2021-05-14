using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class AssignmentsCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IAssignmentsRepository _AssignmentsRepository;

        public AssignmentsCommandHandler(IMapper mapper, IAssignmentsRepository AssignmentsRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _AssignmentsRepository = AssignmentsRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}