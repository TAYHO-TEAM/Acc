using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class GroupAccountRepository : BaseRepository<GroupAccount>, IGroupAccountRepository
    {
        public GroupAccountRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
