using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class ContractorInfoRepository : BaseRepository<ContractorInfo>, IContractorInfoRepository
    {
        public ContractorInfoRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
