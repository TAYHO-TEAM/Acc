using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class CustomFormContentRepository : BaseRepository<CustomFormContent>, ICustomFormContentRepository
    {
        public CustomFormContentRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
