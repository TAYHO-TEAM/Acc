using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class UserInfoRepository : BaseRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
