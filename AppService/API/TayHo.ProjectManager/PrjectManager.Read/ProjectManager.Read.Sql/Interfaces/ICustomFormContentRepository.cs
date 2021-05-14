using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface ICustomFormContentRepository<T> where T : class
    {
        Task<PagingItems<CustomFormContentDetailDTO>> GetCustomFormContentDetailBodyAsync(RequestHasAccountIdFilterParam requetsBaseFilterParam);
        //Task<PagingItems<CustomFormContentDetailBodyDTO>> GetCustomFormContentDetailBodyAsync(RequestHasAccountIdFilterParam requetsBaseFilterParam);
    }
}

