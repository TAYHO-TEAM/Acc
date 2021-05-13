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
        Task<LoadResult> GetAll(int user, string nameEF, DataSourceLoadOptions dataSourceLoadOptionsBase);
        Task<LoadResult> GetAll(int user, string nameEF, DataSourceLoadOptions dataSourceLoadOptionsBase, string searchOperation, string searchValue, List<string> searchExpr);
        Task<MethodResult<T>> Insert(int user, string nameEF, T Model);
    }
}
