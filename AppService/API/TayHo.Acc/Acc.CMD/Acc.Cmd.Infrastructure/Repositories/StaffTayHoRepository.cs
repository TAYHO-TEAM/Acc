using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class StaffTayHoRepository : BaseRepository<StaffTayHo>, IStaffTayHoRepository
    {
        public StaffTayHoRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
