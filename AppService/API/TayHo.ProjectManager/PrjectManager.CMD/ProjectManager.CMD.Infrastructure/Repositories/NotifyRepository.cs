using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NotifyRepository : BaseRepository<Notify>, INotifyRepository
    {
        public NotifyRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
