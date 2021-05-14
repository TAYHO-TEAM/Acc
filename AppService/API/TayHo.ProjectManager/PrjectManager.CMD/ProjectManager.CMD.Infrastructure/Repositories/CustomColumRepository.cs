using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class CustomColumRepository : BaseRepository<CustomColum>, ICustomColumRepository
    {
        public CustomColumRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
