using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class PlanReportRepository : BaseRepository<PlanReport>, IPlanReportRepository
    {
        public PlanReportRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
