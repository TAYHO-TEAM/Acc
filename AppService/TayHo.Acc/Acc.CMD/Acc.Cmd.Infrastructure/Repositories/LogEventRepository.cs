using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class LogEventRepository : BaseRepository<LogEvent>, ILogEventRepository
    {
        public LogEventRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
