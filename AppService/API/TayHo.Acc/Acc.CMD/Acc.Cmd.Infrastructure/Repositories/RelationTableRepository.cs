using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class RelationTableRepository : BaseRepository<RelationTable>, IRelationTableRepository
    {
        public RelationTableRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
