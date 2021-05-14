using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_HangMucRepository : BaseRepository<NS_HangMuc>, INS_HangMucRepository
    {
        public NS_HangMucRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
