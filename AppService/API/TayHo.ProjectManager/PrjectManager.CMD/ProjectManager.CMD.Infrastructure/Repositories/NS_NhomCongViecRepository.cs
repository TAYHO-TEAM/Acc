using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_NhomCongViecRepository : BaseRepository<NS_NhomCongViec>, INS_NhomCongViecRepository
    {
        public NS_NhomCongViecRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
