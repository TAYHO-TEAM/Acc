using DevExtreme.AspNet.Data.ResponseModel;
using Services.Common.DevExpress;
using Services.Common.DomainObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OperationManager.CRUD.BLL.IRepositories.BaseClasses
{
    public interface IQuanLyVanHanhRepository
    {
        Task<LoadResult> GetAll(int user, string nameEF, DataSourceLoadOptions dataSourceLoadOptionsBase);
        Task<LoadResult> GetAll(int user, string nameEF, DataSourceLoadOptions dataSourceLoadOptionsBase, string searchOperation, string searchValue, List<string> searchExpr);
        Task<MethodResult<dynamic>> Insert(string nameEF, dynamic Model);
    }
}
