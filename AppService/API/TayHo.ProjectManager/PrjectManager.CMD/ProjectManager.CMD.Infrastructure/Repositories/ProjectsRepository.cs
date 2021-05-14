using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class ProjectsRepository : BaseRepository<Projects>, IProjectsRepository
    {
        public ProjectsRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
