using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class GroupAccountRepository : BaseRepository<GroupAccount>, IGroupAccountRepository
    {
        public GroupAccountRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
