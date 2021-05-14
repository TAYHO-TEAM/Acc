using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class FilesAttachmentRepository : BaseRepository<FilesAttachment>, IFilesAttachmentRepository
    {
        public FilesAttachmentRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
