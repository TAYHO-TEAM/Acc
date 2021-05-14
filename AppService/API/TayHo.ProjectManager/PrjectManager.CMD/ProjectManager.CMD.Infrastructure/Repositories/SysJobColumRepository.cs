using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class SysJobColumRepository : BaseRepository<SysJobColum>, ISysJobColumRepository
    {
        public SysJobColumRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
