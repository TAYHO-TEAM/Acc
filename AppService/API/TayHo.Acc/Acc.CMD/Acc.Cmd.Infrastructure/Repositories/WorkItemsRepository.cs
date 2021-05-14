using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class WorkItemsRepository : BaseRepository<WorkItems>, IWorkItemsRepository
    {
        public WorkItemsRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
