using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class GroupStagesRepository : BaseRepository<GroupStages>, IGroupStagesRepository
    {
        public GroupStagesRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
