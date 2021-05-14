using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_KhauTru_TheoDoiRepository : BaseRepository<NS_KhauTru_TheoDoi>, INS_KhauTru_TheoDoiRepository
    {
        public NS_KhauTru_TheoDoiRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
