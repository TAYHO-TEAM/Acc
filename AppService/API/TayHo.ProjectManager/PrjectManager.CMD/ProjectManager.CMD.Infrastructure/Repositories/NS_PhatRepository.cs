using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_PhatRepository : BaseRepository<NS_Phat>, INS_PhatRepository
    {
        public NS_PhatRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
