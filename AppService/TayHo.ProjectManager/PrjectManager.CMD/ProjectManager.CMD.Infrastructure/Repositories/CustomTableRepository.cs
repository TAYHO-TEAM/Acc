using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class CustomTableRepository : BaseRepository<CustomTable>, ICustomTableRepository
    {
        public CustomTableRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
