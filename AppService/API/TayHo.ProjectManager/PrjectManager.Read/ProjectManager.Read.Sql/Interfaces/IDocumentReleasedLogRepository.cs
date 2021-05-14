using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface IDocumentReleasedLogRepository<T> where T : class
    {
        Task<PagingItems<T>> GetWithPaggingDetailAsync(RequestHasAccountIdFilterParam requetsBaseFilterParam);
    }
}

