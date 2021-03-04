using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface IDocumentReleasedRepository<T> where T : class
    {
        Task<PagingItems<T>> GetWithPaggingStepPermistionAsync(RequestHasAccountIdFilterParam requetsBaseFilterParam);
        Task<PagingItems<T>> GetWithPaggingResiveIdAsync(RequestHasAccountIdFilterParam requetsBaseFilterParam);
    }
}

