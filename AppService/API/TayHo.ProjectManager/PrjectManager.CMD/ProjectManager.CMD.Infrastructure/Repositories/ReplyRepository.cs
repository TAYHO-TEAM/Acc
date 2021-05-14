using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class ReplyRepository : BaseRepository<Reply>, IReplyRepository
    {
        public ReplyRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
