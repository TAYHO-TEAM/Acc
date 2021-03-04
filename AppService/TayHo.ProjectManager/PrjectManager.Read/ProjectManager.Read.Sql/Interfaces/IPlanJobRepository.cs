using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface IPlanJobRepository<T> where T : class
    {
        Task<PagingItems<T>> GetWithPaggingPermistionAsync(RequestHasAccountPermitFilterParam requetsBaseFilterParam);
    }
}

