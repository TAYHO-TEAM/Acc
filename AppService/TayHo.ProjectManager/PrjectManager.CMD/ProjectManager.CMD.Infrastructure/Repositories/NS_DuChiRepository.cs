using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_DuChiRepository : BaseRepository<NS_DuChi>, INS_DuChiRepository
    {
        public NS_DuChiRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
