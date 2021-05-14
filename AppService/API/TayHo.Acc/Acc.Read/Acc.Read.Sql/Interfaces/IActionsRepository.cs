using Acc.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace Acc.Read.Sql.Interfaces
{
    public interface IActionsRepository<T> where T : class
    {
        Task<PagingItems<T>> GetActionByUserAsync(RequestHasAccountIdFilterParam requestHasAccountIdFilterParam);
    }
}
