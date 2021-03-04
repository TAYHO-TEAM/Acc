using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class PlanProjectRepository : BaseRepository<PlanProject>, IPlanProjectRepository
    {
        public PlanProjectRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
