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
    public class PlanMasterRepository<T> : IPlanMasterRepository<T> where T : class
    {
        protected readonly ISqlConnectionFactory _connectionFactory;

        public PlanMasterRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        public async Task<PagingItems<T>> GetWithPaggingPermistionAsync(RequestHasAccountPermitFilterParam requestBaseFilterParam)
        {
            requestBaseFilterParam.ColumName = requestBaseFilterParam.ColumName?? "*" ;//GetColumnTableName();
            var result = new PagingItems<T>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = requestBaseFilterParam.PageNumber,
                    PageSize = requestBaseFilterParam.PageSize
                }
            };
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_GetDataTableSS_WithPage_Acc_Permit_PlanJob", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
            result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            result.Items = await rs.ReadAsync<T>().ConfigureAwait(false);

            return result;
        }
        public async Task<DataTable> GetReportAsync(int PlanMasterId)
        {
            var table = new DataTable();
            try
            {
                using var conn = await _connectionFactory.CreateConnectionAsync();
                using var rs = conn.ExecuteReader("sp_PlanReport_GetReport", new { PlanMasterId } , commandType: CommandType.StoredProcedure);
               
                table.Load(rs);
                return table;
            }
           
            catch (Exception ex)
            {
                string exm = ex.ToString();
                return new DataTable();
            }
          
        }
    }
}
