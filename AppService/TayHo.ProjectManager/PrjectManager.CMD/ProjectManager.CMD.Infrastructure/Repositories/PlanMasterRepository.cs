using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;
using System.Data;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class PlanMasterRepository : BaseRepository<PlanMaster>, IPlanMasterRepository
    {
        public PlanMasterRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
        public async Task<string> GenCodeAsync(int id, string tableName)
        {
            await using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {

                await cmd.Connection.OpenAsync();
                cmd.CommandText = "sp_GenCode";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.Parameters.Add(new SqlParameter("@TableName", tableName));
                var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                await cmd.Connection.CloseAsync();
                return (string)result;
            }
        }
        public async Task<string> IsGenTitleAsync(int id, string tableName)
        {
            await using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {

                await cmd.Connection.OpenAsync();
                cmd.CommandText = "sp_GenTitle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.Parameters.Add(new SqlParameter("@TableName", tableName));
                var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                await cmd.Connection.CloseAsync();
                return (string)result;
            }
        }
    }
}
