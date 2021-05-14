using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class ProblemCategoryRepository : BaseRepository<ProblemCategory>, IProblemCategoryRepository
    {
        public ProblemCategoryRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
