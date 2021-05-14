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
    public class CustomFormContentRepository<T> : ICustomFormContentRepository<T> where T : class
    {
        protected readonly ISqlConnectionFactory _connectionFactory;

        public CustomFormContentRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        public async Task<PagingItems<CustomFormContentDetailDTO>> GetCustomFormContentDetailBodyAsync(RequestHasAccountIdFilterParam requestBaseFilterParam)
        {
            requestBaseFilterParam.ColumName = requestBaseFilterParam.ColumName ?? "*";
            CustomFormContentDetailDTO CustomFormContentDetailDTO = new CustomFormContentDetailDTO();
            var result = new PagingItems<CustomFormContentDetailDTO>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = requestBaseFilterParam.PageNumber,
                    PageSize = requestBaseFilterParam.PageSize
                }
            };
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_CustomFormContent_GetDetail", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
            //result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            //result.Items = await rs.ReadAsync<T>().ConfigureAwait(false);
            CustomFormContentDetailDTO = rs.Read<CustomFormContentDetailDTO>().Single();
            if(CustomFormContentDetailDTO != null && CustomFormContentDetailDTO.Id >0)
            {
                CustomFormContentDetailDTO.CustomFormDetailDTO = rs.Read<CustomFormDetailDTO>().Single();
                CustomFormContentDetailDTO.CustomFormDetailDTO.CustomFormBodyDetailDTOs = rs.Read<CustomFormBodyDetailDTO>().ToList();
                for (int i = 0; i < CustomFormContentDetailDTO.CustomFormDetailDTO.CustomFormBodyDetailDTOs.Count; i++)
                {
                    requestBaseFilterParam.FindId = CustomFormContentDetailDTO.CustomFormDetailDTO.CustomFormBodyDetailDTOs[i].CustomTableId.ToString();
                    using var rsTableDetail = conn.QueryMultipleAsync("sp_CustomTable_GetDetail", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
                    CustomFormContentDetailDTO.CustomFormDetailDTO.CustomFormBodyDetailDTOs[i].CustomTableDetailDTO = rsTableDetail.Read<CustomTableDetailDTO>().Single();
                    CustomFormContentDetailDTO.CustomFormDetailDTO.CustomFormBodyDetailDTOs[i].CustomTableDetailDTO.CustomColumDetailDTOs = rsTableDetail.Read<CustomColumDetailDTO>().ToList();
                    for (int j = 0; j < CustomFormContentDetailDTO.CustomFormDetailDTO.CustomFormBodyDetailDTOs[i].CustomTableDetailDTO.CustomColumDetailDTOs.Count; j++)
                    {
                        requestBaseFilterParam.ColumName = CustomFormContentDetailDTO.CustomFormDetailDTO.CustomFormBodyDetailDTOs[i].Id.ToString();
                        requestBaseFilterParam.FindId = CustomFormContentDetailDTO.CustomFormDetailDTO.CustomFormBodyDetailDTOs[i].CustomTableDetailDTO.CustomColumDetailDTOs[j].Id.ToString();
                        requestBaseFilterParam.FindParentId = CustomFormContentDetailDTO.Id.ToString();
                        using var rsCellContent = conn.QueryMultipleAsync("sp_CustomCellContent_GetDetail", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
                        CustomFormContentDetailDTO.CustomFormDetailDTO.CustomFormBodyDetailDTOs[i].CustomTableDetailDTO.CustomColumDetailDTOs[j].CustomCellContentDTOs = rsCellContent.Read<CustomCellContentDTO>().ToList();
                    }
                }
            }    
           

            List<CustomFormContentDetailDTO> list = new List<CustomFormContentDetailDTO>();
            list.Add(CustomFormContentDetailDTO);
            result.Items = list;
            return result;
        }
    }
}
