using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_LoaiCongViecRepository : BaseRepository<NS_LoaiCongViec>, INS_LoaiCongViecRepository
    {
        public NS_LoaiCongViecRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
