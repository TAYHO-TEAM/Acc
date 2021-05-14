using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class GroupsRepository : BaseRepository<Groups>, IGroupsRepository
    {
        public GroupsRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
