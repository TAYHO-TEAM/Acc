using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class SysJobTableRepository : BaseRepository<SysJobTable>, ISysJobTableRepository
    {
        public SysJobTableRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
