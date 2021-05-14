using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Data;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface IPlanMasterRepository<T> where T : class
    {
        Task<PagingItems<T>> GetWithPaggingPermistionAsync(RequestHasAccountPermitFilterParam requetsBaseFilterParam);
        Task<DataTable> GetReportAsync(int planMasterId);
    }
}

