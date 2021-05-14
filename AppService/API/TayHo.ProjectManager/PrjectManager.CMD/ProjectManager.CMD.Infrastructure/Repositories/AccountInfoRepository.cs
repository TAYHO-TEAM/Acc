using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class AccountInfoRepository : BaseRepository<AccountInfo>, IAccountInfoRepository
    {
        public AccountInfoRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<string>> IsGetToMailsAsync(int AccountId )
        {
            List<string> toMails = new List<string>();
            await using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {

                await cmd.Connection.OpenAsync();
                cmd.CommandText = "sp_AccountInfo_GetToMail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@AccountId", AccountId));
                var result = await cmd.ExecuteReaderAsync().ConfigureAwait(false);

                while (result.Read())
                {
                    toMails.Add(result["Email"].ToString());
                }
                await cmd.Connection.CloseAsync();
                return toMails;
            }
        }
    }
}
