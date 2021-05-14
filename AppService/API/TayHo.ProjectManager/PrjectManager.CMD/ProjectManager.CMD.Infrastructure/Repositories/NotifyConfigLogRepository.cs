using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NotifyConfigLogRepository : BaseRepository<NotifyConfigLog>, INotifyConfigLogRepository
    {
        public NotifyConfigLogRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
