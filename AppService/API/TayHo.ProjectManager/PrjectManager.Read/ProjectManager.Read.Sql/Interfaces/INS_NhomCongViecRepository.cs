using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface INS_NhomCongViecRepository<T> where T : class
    {
        Task<PagingItems<T>> GetNhomCongViec_NhomCongViecDetailAsync(RequestTreeListBaseFilterParam requetsBaseFilterParam); 
    }

}
