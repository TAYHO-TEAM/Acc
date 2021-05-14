using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class ProjectsRepository : BaseRepository<Projects>, IProjectsRepository
    {
        public ProjectsRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
