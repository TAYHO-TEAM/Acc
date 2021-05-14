using Acc.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace Acc.Read.Sql.Interfaces
{
    public interface IDOBaseRepository<T> where T : class
    {
        Task<PagingItems<T>> GetWithPaggingAsync(RequestBaseFilterParam requetsBaseFilterParam);
        Task<PagingItems<T>> GetWithPaggingFKAsync(RequestParentBaseFilterParam requetsBaseFilterParam);
        Task<PagingItems<T>> GetWithPaggingAccountFKAsync(RequestHasAccountIdFilterParam requestHasAccountIdFilterParam);
    }
}
