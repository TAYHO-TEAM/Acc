using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface ICustomTableRepository<T> where T : class
    {
        Task<PagingItems<CustomTableDetailDTO>> GetCustomTableDetailAsync(RequestHasAccountIdFilterParam requetsBaseFilterParam);
    }
}

