using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class SysAutoSendMailRepository : BaseRepository<SysAutoSendMail>, ISysAutoSendMailRepository
    {
        public SysAutoSendMailRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
