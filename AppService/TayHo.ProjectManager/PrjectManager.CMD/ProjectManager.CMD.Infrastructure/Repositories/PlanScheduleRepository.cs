using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class PlanScheduleRepository : BaseRepository<PlanSchedule>, IPlanScheduleRepository
    {
        public PlanScheduleRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
