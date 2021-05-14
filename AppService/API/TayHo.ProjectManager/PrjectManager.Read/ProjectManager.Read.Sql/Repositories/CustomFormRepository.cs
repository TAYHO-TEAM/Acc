using Dapper;
using Dapper.Common;
using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Repositories
{
    public class CustomFormRepository<T> : ICustomFormRepository<T> where T : class
    {
        protected readonly ISqlConnectionFactory _connectionFactory;

        public CustomFormRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        public async Task<PagingItems<CustomFormDetailDTO>> GetCustomFormDetailAsync(RequestHasAccountIdFilterParam requestBaseFilterParam)
        {
            requestBaseFilterParam.ColumName = requestBaseFilterParam.ColumName ?? "*";
            CustomFormDetailDTO CustomFormDetailDTO = new CustomFormDetailDTO();
            var result = new PagingItems<CustomFormDetailDTO>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = requestBaseFilterParam.PageNumber,
                    PageSize = requestBaseFilterParam.PageSize
                }
            };
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_CustomForm_GetDetail", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
            //result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            //result.Items = await rs.ReadAsync<T>().ConfigureAwait(false);
            CustomFormDetailDTO = rs.Read<CustomFormDetailDTO>().Single();
            CustomFormDetailDTO.CustomFormBodyDetailDTOs = rs.Read<CustomFormBodyDetailDTO>().ToList();
            for (int i = 0; i < CustomFormDetailDTO.CustomFormBodyDetailDTOs.Count; i++)
            {
                requestBaseFilterParam.FindId = CustomFormDetailDTO.CustomFormBodyDetailDTOs[i].CustomTableId.ToString();
                using var rsTableDetail = conn.QueryMultipleAsync("sp_CustomTable_GetDetail", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
                CustomFormDetailDTO.CustomFormBodyDetailDTOs[i].CustomTableDetailDTO = rsTableDetail.Read<CustomTableDetailDTO>().Single();
                CustomFormDetailDTO.CustomFormBodyDetailDTOs[i].CustomTableDetailDTO.CustomColumDetailDTOs = rsTableDetail.Read<CustomColumDetailDTO>().ToList();
            }
            List<CustomFormDetailDTO> list = new List<CustomFormDetailDTO>();
            list.Add(CustomFormDetailDTO);
            result.Items = list;
            return result;
        }
        //public async Task<PagingItems<CustomFormDetailBodyDTO>> GetCustomFormDetailBodyAsync(RequestHasAccountIdFilterParam requestBaseFilterParam)
        //{
        //    requestBaseFilterParam.ColumName = requestBaseFilterParam.ColumName ?? "*";
        //    CustomFormDetailBodyDTO CustomFormDetailBodyDTO = new CustomFormDetailBodyDTO();
        //    var result = new PagingItems<CustomFormDetailBodyDTO>
        //    {
        //        PagingInfo = new PagingInfo
        //        {
        //            PageNumber = requestBaseFilterParam.PageNumber,
        //            PageSize = requestBaseFilterParam.PageSize
        //        }
        //    };
        //    using var conn = await _connectionFactory.CreateConnectionAsync();
        //    using var rs = conn.QueryMultipleAsync("sp_CustomForm_GetDetailBody", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
        //    //result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
        //    //result.Items = await rs.ReadAsync<T>().ConfigureAwait(false);
        //    CustomFormDetailBodyDTO = rs.Read<CustomFormDetailBodyDTO>().Single();
        //    CustomFormDetailBodyDTO.CustomFormBodyDetailDTOs = rs.Read<CustomFormBodyDetailDTO>().ToList();
        //    for(int i =0; i< CustomFormDetailBodyDTO.CustomFormBodyDetailDTOs.Count;i++)
        //    {
        //        requestBaseFilterParam.FindId = CustomFormDetailBodyDTO.CustomFormBodyDetailDTOs[i].CustomTableId.ToString();
        //        using var rsTableDetail = conn.QueryMultipleAsync("sp_CustomTable_GetDetail", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
        //        CustomTableDTO customTableDTO = rsTableDetail.Read<CustomTableDTO>().Single();
        //        CustomFormDetailBodyDTO.CustomFormBodyDetailDTOs[i].CustomColumDetailDTOs = rsTableDetail.Read<CustomColumDetailDTO>().ToList();
        //    }    
        //    List<CustomFormDetailBodyDTO> list = new List<CustomFormDetailBodyDTO>();
        //    list.Add(CustomFormDetailBodyDTO);
        //    result.Items = list;
        //    return result;
        //}
    }
}
