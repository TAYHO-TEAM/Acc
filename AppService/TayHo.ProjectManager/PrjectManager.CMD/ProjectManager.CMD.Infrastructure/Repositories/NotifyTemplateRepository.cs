using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NotifyTemplateRepository : BaseRepository<NotifyTemplate>, INotifyTemplateRepository
    {
        public NotifyTemplateRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
