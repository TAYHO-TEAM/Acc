using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface ISysJobRepository<T> where T : class
    {
        Task<PagingItems<SysJobDataBaseDTO>> GetDataBaseAsync(RequestSysJobFilterParam requetsBaseFilterParam);
        Task<PagingItems<SysJobStoreProcedureDTO>> GetStoreProcedureAsync(RequestSysJobFilterParam requetsBaseFilterParam);
        Task<PagingItems<SysJobParameterDTO>> GetParameterAsync(RequestSysJobFilterParam requetsBaseFilterParam);
    }
}

