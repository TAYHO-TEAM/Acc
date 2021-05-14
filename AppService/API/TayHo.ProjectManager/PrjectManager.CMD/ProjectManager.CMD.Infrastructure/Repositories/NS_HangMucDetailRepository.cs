using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_HangMucDetailRepository : BaseRepository<NS_HangMucDetail>, INS_HangMucDetailRepository
    {
        public NS_HangMucDetailRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
