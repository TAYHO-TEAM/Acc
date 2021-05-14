using Acc.Read.Sql.Interfaces;
using Acc.Read.Sql.Parameters;
using Dapper;
using Dapper.Common;
using Services.Common.DomainObjects;
using Services.Common.Paging;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Acc.Read.Sql.Repositories
{
    public class ActionsRepository<T> : IActionsRepository<T> where T : class
    {
        protected readonly ISqlConnectionFactory _connectionFactory;

        public ActionsRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        public async Task<PagingItems<T>> GetActionByUserAsync(RequestHasAccountIdFilterParam requestHasAccountIdFilterParam)
        {
            requestHasAccountIdFilterParam.ColumName =  "*";//GetColumnTableName();
            var result = new PagingItems<T>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = requestHasAccountIdFilterParam.PageNumber,
                    PageSize = requestHasAccountIdFilterParam.PageSize
                }
            };
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_GetActions_ByAccountHasPermistion", requestHasAccountIdFilterParam, commandType: CommandType.StoredProcedure).Result;
            result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            result.Items = await rs.ReadAsync<T>().ConfigureAwait(false);

            return result;
        }
    }
}
