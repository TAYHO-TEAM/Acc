using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class PlanRegisterRepository : BaseRepository<PlanRegister>, IPlanRegisterRepository
    {
        public PlanRegisterRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
