using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_ThucChiRepository : BaseRepository<NS_ThucChi>, INS_ThucChiRepository
    {
        public NS_ThucChiRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
