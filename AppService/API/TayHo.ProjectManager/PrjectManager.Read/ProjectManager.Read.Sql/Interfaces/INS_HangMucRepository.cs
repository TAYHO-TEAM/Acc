using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface INS_HangMucRepository<T> where T : class
    {
        Task<PagingItems<T>> GetHangMuc_HangMucDetailAsync(RequestTreeListBaseFilterParam requetsBaseFilterParam); 
        Task<PagingItems<T>> GetHangMuc_GetBy_GoiThauAsync(RequestBaseFilterParam requetsBaseFilterParam); 
    }

}
