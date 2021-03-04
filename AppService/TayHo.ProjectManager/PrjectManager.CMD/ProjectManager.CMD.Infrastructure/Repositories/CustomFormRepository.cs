using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class CustomFormRepository : BaseRepository<CustomForm>, ICustomFormRepository
    {
        public CustomFormRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
