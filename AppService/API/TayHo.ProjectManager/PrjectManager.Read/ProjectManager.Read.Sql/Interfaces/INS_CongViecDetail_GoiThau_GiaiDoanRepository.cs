using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface INS_CongViecDetail_GoiThau_GiaiDoanRepository<T> where T : class
    {
        Task<PagingItems<T>> GetCongViecDetail_GoiThau_GiaiDoanAsync(RequestBaseFilterParam requetsBaseFilterParam); 
    }

}
