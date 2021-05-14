using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_NhomChiPhiRepository : BaseRepository<NS_NhomChiPhi>, INS_NhomChiPhiRepository
    {
        public NS_NhomChiPhiRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
