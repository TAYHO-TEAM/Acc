using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_Phat_TheoDoiRepository : BaseRepository<NS_Phat_TheoDoi>, INS_Phat_TheoDoiRepository
    {
        public NS_Phat_TheoDoiRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
