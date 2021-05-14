using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_KhauTruRepository : BaseRepository<NS_KhauTru>, INS_KhauTruRepository
    {
        public NS_KhauTruRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
