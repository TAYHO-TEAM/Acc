using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class PermistionsRepository : BaseRepository<Permistions>, IPermistionsRepository
    {
        public PermistionsRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
