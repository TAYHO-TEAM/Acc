using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanReportCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IPlanReportRepository _planReportRepository;

        public PlanReportCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IPlanReportRepository PlanReportRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _planReportRepository = PlanReportRepository;
        }
    }
}
