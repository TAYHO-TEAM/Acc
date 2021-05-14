using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class AccountsRepository : BaseRepository<Accounts>, IAccountsRepository
    {
        public AccountsRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
