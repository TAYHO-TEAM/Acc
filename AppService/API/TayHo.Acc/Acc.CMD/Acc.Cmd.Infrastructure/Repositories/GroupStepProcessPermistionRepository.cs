using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class GroupStepProcessPermistionRepository : BaseRepository<GroupStepProcessPermistion>, IGroupStepProcessPermistionRepository
    {
        public GroupStepProcessPermistionRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
