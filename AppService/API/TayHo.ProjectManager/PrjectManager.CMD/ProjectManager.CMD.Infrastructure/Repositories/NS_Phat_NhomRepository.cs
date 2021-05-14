using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_Phat_NhomRepository : BaseRepository<NS_Phat_Nhom>, INS_Phat_NhomRepository
    {
        public NS_Phat_NhomRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
