using DevExtreme.AspNet.Data.ResponseModel;
using OperationManager.CRUD.DAL.DTO.BaseClasses;
using Services.Common.DevExpress;
using Services.Common.DomainObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OperationManager.CRUD.BLL.IRepositories.BaseClasses
{
    public interface IQuanLyVanHanhRepository<T> where T : DOBase
    {
        Task<LoadResult> GetAll(int user, string nameEF, DataLoadOptionsHelper dataSourceLoadOptionsBase);
        Task<LoadResult> GetAll(int user, string nameEF, DataSourceLoadOptionsHelper dataSourceLoadOptionsBase, string searchOperation, string searchValue, List<string> searchExpr);
        Task<MethodResult<T>> Insert(int user, string nameEF, T Model);
        Task<MethodResult<T>> Update(int user, string nameEF, T model);
        Task<MethodResult<T>> Delete(int user, string nameEF, int key);
    }
}
