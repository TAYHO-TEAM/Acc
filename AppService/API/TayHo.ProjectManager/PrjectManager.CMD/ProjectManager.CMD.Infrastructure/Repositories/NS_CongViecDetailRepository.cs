using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_CongViecDetailRepository : BaseRepository<NS_CongViecDetail>, INS_CongViecDetailRepository
    {
        public NS_CongViecDetailRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
