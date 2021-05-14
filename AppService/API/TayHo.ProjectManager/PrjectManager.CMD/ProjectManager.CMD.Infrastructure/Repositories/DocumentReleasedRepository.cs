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
    public class DocumentReleasedRepository : BaseRepository<DocumentReleased>, IDocumentReleasedRepository
    {
        public DocumentReleasedRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> IsCreatedDocumentReleasedAsync(int DocumentTypeId, int AccountId, int Id)
        {
            await using var cmd = _dbContext.Database.GetDbConnection().CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = "sp_DocumentReleased_CreateByAccountID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DocumentTypeId", DocumentTypeId));
            cmd.Parameters.Add(new SqlParameter("@AccountId", AccountId));
            cmd.Parameters.Add(new SqlParameter("@DocumentReleasedId", Id));
            var result = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
            await cmd.Connection.CloseAsync();
            return (bool)(result == 0 ? false : true);
        }
        public async Task<string> IsGetTitleDocumentReleasedAsync(int ProjectId =0 , int WorkItemId =0, int DocumentTypeId = 0)
        {
            await using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {

                await cmd.Connection.OpenAsync();
                cmd.CommandText = "sp_DocumentRelease_GetTitle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProjectId", ProjectId));
                cmd.Parameters.Add(new SqlParameter("@WorkItemId", WorkItemId));
                cmd.Parameters.Add(new SqlParameter("@DocumentTypeId", DocumentTypeId));
                var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                await cmd.Connection.CloseAsync();
                return (string)result;
            }
        }
        public async Task DocumentReleasedProcessAsync()
        {
            await using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {

                await cmd.Connection.OpenAsync();
                cmd.CommandText = "sp_DocumentReleased_Process";
                cmd.CommandType = CommandType.StoredProcedure;
                var result = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                await cmd.Connection.CloseAsync();
            }
        }
        public async Task<List<string>> IsGetToMailsAsync(int DocumentTypeId = 0)
        {
            List<string> toMails = new List<string>();
            await using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {

                await cmd.Connection.OpenAsync();
                cmd.CommandText = "sp_DocumentReleasedAccount_GetToMail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DocumentReleasedId", DocumentTypeId));
                var result = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
                
                while (result.Read())
                {
                    toMails.Add(result["Email"].ToString());
                }
                await cmd.Connection.CloseAsync();
                return toMails;
            }
        }
        public async Task<string> GetBodyContentWithTempId(int DocumentTypeId = 0 , int TemplateId = 0)
        {
            List<string> toMails = new List<string>();
            await using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {

                await cmd.Connection.OpenAsync();
                cmd.CommandText = "sp_DocumentReleased_ConvertBodyContent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DocumentReleasedId", DocumentTypeId));
                cmd.Parameters.Add(new SqlParameter("@TempalteMailId", TemplateId));
                var result = await cmd.ExecuteReaderAsync().ConfigureAwait(false);

                while (result.Read())
                {
                    toMails.Add(result["BodyHtml"].ToString());
                }
                await cmd.Connection.CloseAsync();
                return toMails[0].ToString();
            }
        }
    }
}
