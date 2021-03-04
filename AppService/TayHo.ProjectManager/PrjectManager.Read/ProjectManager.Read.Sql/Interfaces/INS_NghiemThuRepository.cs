using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface INS_NghiemThuRepository<T> where T : class
    {
        Task<PagingItems<T>> GetNS_NghiemThuDetailAsync(RequestBaseFilterParam requetsBaseFilterParam); 
    }

}
