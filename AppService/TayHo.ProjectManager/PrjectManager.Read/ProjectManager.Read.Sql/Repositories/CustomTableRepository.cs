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
    public class CustomTableRepository<T> : ICustomTableRepository<T> where T : class
    {
        protected readonly ISqlConnectionFactory _connectionFactory;

        public CustomTableRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        public async Task<PagingItems<CustomTableDetailDTO>> GetCustomTableDetailAsync(RequestHasAccountIdFilterParam requestBaseFilterParam)
        {
            requestBaseFilterParam.ColumName = requestBaseFilterParam.ColumName ?? "*";
            CustomTableDetailDTO customTableDetailDTO = new CustomTableDetailDTO();
            var result = new PagingItems<CustomTableDetailDTO>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = requestBaseFilterParam.PageNumber,
                    PageSize = requestBaseFilterParam.PageSize
                }
            };
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_CustomTable_GetDetail", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
            //result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            //result.Items = await rs.ReadAsync<T>().ConfigureAwait(false);
            customTableDetailDTO = rs.Read<CustomTableDetailDTO>().Single();
            customTableDetailDTO.CustomColumDetailDTOs = rs.Read<CustomColumDetailDTO>().ToList();
            List<CustomTableDetailDTO> list = new List<CustomTableDetailDTO>();
            list.Add(customTableDetailDTO);
            //IEnumerable<CustomTableDetailDTO> enumerable = list;
            result.Items = list;
            return result;
        }
    }
}
