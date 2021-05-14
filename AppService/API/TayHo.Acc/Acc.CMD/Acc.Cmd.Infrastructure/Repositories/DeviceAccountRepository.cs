using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class DeviceAccountRepository : BaseRepository<DeviceAccount>, IDeviceAccountRepository
    {
        public DeviceAccountRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
