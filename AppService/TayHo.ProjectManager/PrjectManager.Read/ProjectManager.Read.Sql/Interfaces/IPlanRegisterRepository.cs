using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface IPlanRegisterRepository<T> where T : class
    {
        //Task<PagingItems<T>> GetWithPaggingAsync(RequestBaseFilterParam requetsBaseFilterParam);GetWithDetailAsync
        Task<PagingItems<T>> GetWithPaggingContractorInfoAsync(RequestHasAccountIdFilterParam requetsBaseFilterParam);
    }
}

