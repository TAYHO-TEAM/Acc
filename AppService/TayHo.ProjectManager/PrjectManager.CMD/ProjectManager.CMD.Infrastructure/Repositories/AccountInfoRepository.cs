using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class AccountInfoRepository : BaseRepository<AccountInfo>, IAccountInfoRepository
    {
        public AccountInfoRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
