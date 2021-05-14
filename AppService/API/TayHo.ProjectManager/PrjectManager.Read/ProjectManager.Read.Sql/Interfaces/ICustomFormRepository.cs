using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface ICustomFormRepository<T> where T : class
    {
        Task<PagingItems<CustomFormDetailDTO>> GetCustomFormDetailAsync(RequestHasAccountIdFilterParam requetsBaseFilterParam);
        //Task<PagingItems<CustomFormDetailBodyDTO>> GetCustomFormDetailBodyAsync(RequestHasAccountIdFilterParam requetsBaseFilterParam);
    }
}

