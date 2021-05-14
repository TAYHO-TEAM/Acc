using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_ReasonRepository : BaseRepository<NS_Reason>, INS_ReasonRepository
    {
        public NS_ReasonRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
