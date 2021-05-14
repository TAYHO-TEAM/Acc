using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class CustomFormBodyRepository : BaseRepository<CustomFormBody>, ICustomFormBodyRepository
    {
        public CustomFormBodyRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
