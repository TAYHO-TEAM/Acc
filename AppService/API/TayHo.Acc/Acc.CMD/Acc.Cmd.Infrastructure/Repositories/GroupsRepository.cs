using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class GroupsRepository : BaseRepository<Groups>, IGroupsRepository
    {
        public GroupsRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
