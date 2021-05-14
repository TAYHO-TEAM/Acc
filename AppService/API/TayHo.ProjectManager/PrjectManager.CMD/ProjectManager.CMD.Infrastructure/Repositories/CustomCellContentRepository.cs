using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class CustomCellContentRepository : BaseRepository<CustomCellContent>, ICustomCellContentRepository
    {
        public CustomCellContentRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
