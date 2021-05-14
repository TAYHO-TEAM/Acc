using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class ContractorInfoRepository : BaseRepository<ContractorInfo>, IContractorInfoRepository
    {
        public ContractorInfoRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
