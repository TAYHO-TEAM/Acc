using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class CustomFormAccountRepository : BaseRepository<CustomFormAccount>, ICustomFormAccountRepository
    {
        public CustomFormAccountRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
