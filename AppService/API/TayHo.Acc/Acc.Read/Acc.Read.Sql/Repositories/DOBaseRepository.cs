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
    public class DOBaseRepository<T> : IDOBaseRepository<T> where T : class
    {
        protected readonly ISqlConnectionFactory _connectionFactory;

        public DOBaseRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public async Task<PagingItems<T>> GetWithPaggingAsync(RequestBaseFilterParam requestBaseFilterParam)
        {
            requestBaseFilterParam.ColumName = new GetColumName<T>().GetColumnTableName();
            var result = new PagingItems<T>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = requestBaseFilterParam.PageNumber,
                    PageSize = requestBaseFilterParam.PageSize
                }
            };
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_GetDataTableSS_WithPage", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
            result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            result.Items = await rs.ReadAsync<T>().ConfigureAwait(false);
            return result;
        }
        public async Task<PagingItems<T>> GetWithPaggingFKAsync(RequestParentBaseFilterParam requestBaseFilterParam)
        {
            requestBaseFilterParam.ColumName = requestBaseFilterParam.ColumName ?? "*";//GetColumnTableName();
            var result = new PagingItems<T>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = requestBaseFilterParam.PageNumber,
                    PageSize = requestBaseFilterParam.PageSize
                }
            };
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_GetDataTableSS_WithPage_FK", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
            result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            result.Items = await rs.ReadAsync<T>().ConfigureAwait(false);

            return result;
        }
        public async Task<PagingItems<T>> GetWithPaggingAccountFKAsync(RequestHasAccountIdFilterParam requestHasAccountIdFilterParam)
        {
            requestHasAccountIdFilterParam.ColumName = requestHasAccountIdFilterParam.ColumName ?? "*";//GetColumnTableName();
            var result = new PagingItems<T>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = requestHasAccountIdFilterParam.PageNumber,
                    PageSize = requestHasAccountIdFilterParam.PageSize
                }
            };
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_GetDataTableSS_WithPage_AccountID_FK", requestHasAccountIdFilterParam, commandType: CommandType.StoredProcedure).Result;
            result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            result.Items = await rs.ReadAsync<T>().ConfigureAwait(false);

            return result;
        }
    }
}
