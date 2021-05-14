using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class StepsProcessRepository : BaseRepository<StepsProcess>, IStepsProcessRepository
    {
        public StepsProcessRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
