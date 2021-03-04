using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class PlanAccountRepository : BaseRepository<PlanAccount>, IPlanAccountRepository
    {
        public PlanAccountRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
