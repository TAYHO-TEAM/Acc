using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_CongViecRepository : BaseRepository<NS_CongViec>, INS_CongViecRepository
    {
        public NS_CongViecRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
