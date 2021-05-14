using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_GoiThauRepository : BaseRepository<NS_GoiThau>, INS_GoiThauRepository
    {
        public NS_GoiThauRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
