using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class CategorysRepository : BaseRepository<Categorys>, ICategorysRepository
    {
        public CategorysRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
