using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class GroupPermistionRepository : BaseRepository<GroupPermistion>, IGroupPermistionRepository
    {
        public GroupPermistionRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
