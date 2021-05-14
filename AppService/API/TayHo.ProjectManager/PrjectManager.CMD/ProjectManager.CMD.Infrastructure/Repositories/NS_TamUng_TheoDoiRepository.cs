using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_TamUng_TheoDoiRepository : BaseRepository<NS_TamUng_TheoDoi>, INS_TamUng_TheoDoiRepository
    {
        public NS_TamUng_TheoDoiRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
