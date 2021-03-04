using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NotifyAccountRepository : BaseRepository<NotifyAccount>, INotifyAccountRepository
    {
        public NotifyAccountRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
