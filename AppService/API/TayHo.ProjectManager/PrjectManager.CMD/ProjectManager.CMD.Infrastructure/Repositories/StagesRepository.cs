using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class StagesRepository : BaseRepository<Stages>, IStagesRepository
    {
        public StagesRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
