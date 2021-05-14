using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class GroupStagesRepository : BaseRepository<GroupStages>, IGroupStagesRepository
    {
        public GroupStagesRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
