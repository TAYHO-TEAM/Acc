using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class GroupActionPermistionRepository : BaseRepository<GroupActionPermistion>, IGroupActionPermistionRepository
    {
        public GroupActionPermistionRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
