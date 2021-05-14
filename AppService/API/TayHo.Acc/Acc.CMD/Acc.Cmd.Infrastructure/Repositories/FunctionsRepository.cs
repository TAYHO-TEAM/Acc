using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class FunctionsRepository : BaseRepository<Functions>, IFunctionsRepository
    {
        public FunctionsRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
