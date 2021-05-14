using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class RequestsRepository : BaseRepository<Requests>, IRequestsRepository
    {
        public RequestsRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
