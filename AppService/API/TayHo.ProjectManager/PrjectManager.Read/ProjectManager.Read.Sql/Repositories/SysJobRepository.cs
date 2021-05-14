using Dapper;
using Dapper.Common;
using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Repositories
{
    public class SysJobRepository<T> : ISysJobRepository<T> where T : class
    {
        protected readonly ISqlConnectionFactory _connectionFactory;

        public SysJobRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        //public async Task<PagingItems<T>> GetWithPaggingPermistionAsync(RequestHasAccountPermitFilterParam requestBaseFilterParam)
        //{
        //    requestBaseFilterParam.ColumName = requestBaseFilterParam.ColumName?? "*" ;//GetColumnTableName();
        //    var result = new PagingItems<T>
        //    {
        //        PagingInfo = new PagingInfo
        //        {
        //            PageNumber = requestBaseFilterParam.PageNumber,
        //            PageSize = requestBaseFilterParam.PageSize
        //        }
        //    };
        //    using var conn = await _connectionFactory.CreateConnectionAsync();
        //    using var rs = conn.QueryMultipleAsync("sp_GetDataTableSS_WithPage_Acc_Permit_SysJob", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
        //    result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
        //    result.Items = await rs.ReadAsync<T>().ConfigureAwait(false);

        //    return result;
        //}
        public async Task<PagingItems<SysJobDataBaseDTO>> GetDataBaseAsync(RequestSysJobFilterParam requestBaseFilterParam)
        {
            var result = new PagingItems<SysJobDataBaseDTO>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = 1,
                    PageSize = 0
                }
            };
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_Sys_GetDataBase", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
            result.Items = await rs.ReadAsync<SysJobDataBaseDTO>().ConfigureAwait(false);
            return result;
        }
        public async Task<PagingItems<SysJobStoreProcedureDTO>> GetStoreProcedureAsync(RequestSysJobFilterParam requestBaseFilterParam)
        {
            var result = new PagingItems<SysJobStoreProcedureDTO>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = 1,
                    PageSize = 0
                }
            };
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_Sys_GetDataBase", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
            //result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            result.Items = await rs.ReadAsync<SysJobStoreProcedureDTO>().ConfigureAwait(false);

            return result;
        }
        public async Task<PagingItems<SysJobParameterDTO>> GetParameterAsync(RequestSysJobFilterParam requestBaseFilterParam)
        {
            var result = new PagingItems<SysJobParameterDTO>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = 1,
                    PageSize = 0
                }
            };
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_Sys_GetParameter", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
            //result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            result.Items = await rs.ReadAsync<SysJobParameterDTO>().ConfigureAwait(false);

            return result;
        }
    }
}
