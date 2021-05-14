using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class ResponseRegistReplyRepository : BaseRepository<ResponseRegistReply>, IResponseRegistReplyRepository
    {
        public ResponseRegistReplyRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
