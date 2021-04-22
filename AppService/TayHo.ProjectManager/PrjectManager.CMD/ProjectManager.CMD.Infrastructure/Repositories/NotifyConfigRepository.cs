using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NotifyConfigRepository : BaseRepository<NotifyConfig>, INotifyConfigRepository
    {
        public NotifyConfigRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
