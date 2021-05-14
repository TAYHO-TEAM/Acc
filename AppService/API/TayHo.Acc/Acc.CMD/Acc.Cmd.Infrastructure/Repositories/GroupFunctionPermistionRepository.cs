using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class GroupFunctionPermistionRepository : BaseRepository<GroupFunctionPermistion>, IGroupFunctionPermistionRepository
    {
        public GroupFunctionPermistionRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
