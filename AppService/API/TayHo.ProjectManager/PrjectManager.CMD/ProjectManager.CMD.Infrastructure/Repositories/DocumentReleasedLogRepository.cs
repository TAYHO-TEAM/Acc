using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class DocumentReleasedLogRepository : BaseRepository<DocumentReleasedLog>, IDocumentReleasedLogRepository
    {
        public DocumentReleasedLogRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
