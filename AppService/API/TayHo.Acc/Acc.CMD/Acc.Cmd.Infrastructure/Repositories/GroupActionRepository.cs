using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class GroupActionRepository : BaseRepository<GroupAction>, IGroupActionRepository
    {
        public GroupActionRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
