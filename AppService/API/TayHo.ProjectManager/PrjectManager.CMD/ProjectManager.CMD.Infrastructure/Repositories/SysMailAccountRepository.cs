using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class SysMailAccountRepository : BaseRepository<SysMailAccount>, ISysMailAccountRepository
    {
        public SysMailAccountRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
