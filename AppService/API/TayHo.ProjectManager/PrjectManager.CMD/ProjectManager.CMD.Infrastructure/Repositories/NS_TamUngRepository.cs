using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_TamUngRepository : BaseRepository<NS_TamUng>, INS_TamUngRepository
    {
        public NS_TamUngRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
