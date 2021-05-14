using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_NhomCongViecDetailRepository : BaseRepository<NS_NhomCongViecDetail>, INS_NhomCongViecDetailRepository
    {
        public NS_NhomCongViecDetailRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
