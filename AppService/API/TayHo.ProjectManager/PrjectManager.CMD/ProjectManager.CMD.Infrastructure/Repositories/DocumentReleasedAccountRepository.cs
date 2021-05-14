using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class DocumentReleasedAccountRepository : BaseRepository<DocumentReleasedAccount>, IDocumentReleasedAccountRepository
    {
        public DocumentReleasedAccountRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
