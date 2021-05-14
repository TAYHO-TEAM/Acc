using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class TemplateMailRepository : BaseRepository<TemplateMail>, ITemplateMailRepository
    {
        public TemplateMailRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
