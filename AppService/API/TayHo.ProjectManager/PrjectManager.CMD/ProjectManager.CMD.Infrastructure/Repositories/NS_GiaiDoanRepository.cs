using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_GiaiDoanRepository : BaseRepository<NS_GiaiDoan>, INS_GiaiDoanRepository
    {
        public NS_GiaiDoanRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
