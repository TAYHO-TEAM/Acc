using Microsoft.EntityFrameworkCore;
using Services.Common.APIs.Cmd.EF.Extensions;
using System.Data.Common;

namespace Services.Common.APIs.Cmd.EF
{
    public class SprocRepository 
    {
        private readonly DbContext _dbContext;
        public SprocRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbCommand GetStoredProcedure(
            string name,
            params (string, object)[] nameValueParams)
        {
            return _dbContext
                .LoadStoredProcedure(name)
                .WithSqlParams(nameValueParams);
        }
        public DbCommand GetStoredProcedure(string name)
        {
            return _dbContext.LoadStoredProcedure(name);
        }
    }
}
