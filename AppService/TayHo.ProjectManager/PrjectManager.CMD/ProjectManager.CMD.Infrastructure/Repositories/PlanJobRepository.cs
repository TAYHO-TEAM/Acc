using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class PlanJobRepository : BaseRepository<PlanJob>, IPlanJobRepository
    {
        public PlanJobRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
