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
    public class RequestRegistRepository<T> : IRequestRegistRepository<T> where T : class
    {
        protected readonly ISqlConnectionFactory _connectionFactory;

        public RequestRegistRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        public async Task<PagingItems<T>> GetWithPaggingStepPermistionAsync(RequestHasAccountIdFilterParam requestBaseFilterParam)
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
            using var rs = conn.QueryMultipleAsync("sp_RequestRegist_GetByStepPermistion", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
            result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            result.Items = await rs.ReadAsync<T>().ConfigureAwait(false);

            return result;
        }
        public async Task<PagingItems<RequestRegistDetailDTO>> GetWithDetailAsync(RequestHasAccountIdFilterParam requestBaseFilterParam)
        {
            requestBaseFilterParam.ColumName = requestBaseFilterParam.ColumName ?? "*";//GetColumnTableName();
            RequestRegistDetailDTO requestRegistDetailDTO = new RequestRegistDetailDTO();
           
            var result = new PagingItems<RequestRegistDetailDTO>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = requestBaseFilterParam.PageNumber,
                    PageSize = requestBaseFilterParam.PageSize
                }
            };
            
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_RequestRegist_GetDetail", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
            //result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            requestRegistDetailDTO = rs.Read<RequestRegistDetailDTO>().Single();
            requestRegistDetailDTO.ResponseRegistDTOs = new List<ResponseRegistDTO>();
            requestRegistDetailDTO.ResponseRegistDTOs = rs.Read<ResponseRegistDTO>().ToList();
            List<RequestRegistDetailDTO> list = new List<RequestRegistDetailDTO>();
            list.Add(requestRegistDetailDTO);
            result.Items = list;
            return result;
        }

    }
}
