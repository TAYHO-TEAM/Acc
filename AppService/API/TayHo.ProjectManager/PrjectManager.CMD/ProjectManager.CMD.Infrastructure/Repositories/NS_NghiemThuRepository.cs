using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_NghiemThuRepository : BaseRepository<NS_NghiemThu>, INS_NghiemThuRepository
    {
        public NS_NghiemThuRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
