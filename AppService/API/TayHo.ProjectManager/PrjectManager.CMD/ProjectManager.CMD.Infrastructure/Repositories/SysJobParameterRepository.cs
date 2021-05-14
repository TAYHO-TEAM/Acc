using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class SysJobParameterRepository : BaseRepository<SysJobParameter>, ISysJobParameterRepository
    {
        public SysJobParameterRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
