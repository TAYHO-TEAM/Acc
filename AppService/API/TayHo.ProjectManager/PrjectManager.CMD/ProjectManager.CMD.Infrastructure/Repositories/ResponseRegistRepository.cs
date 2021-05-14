using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class ResponseRegistRepository : BaseRepository<ResponseRegist>, IResponseRegistRepository
    {
        public ResponseRegistRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
