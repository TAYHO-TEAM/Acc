using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Http;
using OperationManager.CRUD.DAL.DTO.BaseClasses;
using Services.Common.DevExpress;
using Services.Common.DomainObjects;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace OperationManager.CRUD.BLL.IRepositories.BaseClasses
{
    public interface IQuanLyDuAnRepository<T> where T : DOBase
    {
        Task<LoadResult> GetAll(int user, string nameEF, DataLoadOptionsHelper dataSourceLoadOptionsBase);
        Task<LoadResult> GetAll(int user, string nameEF, DataSourceLoadOptionsHelper dataSourceLoadOptionsBase, string searchOperation, string searchValue, List<string> searchExpr);
        Task<MethodResult<T>> Insert(int user, string nameEF, T Model, IFormFileCollection formFile = null);
        Task<MethodResult<T>> Update(int user, string nameEF, T model, IFormFileCollection formFile = null);
        Task<MethodResult<T>> Delete(int user, string nameEF, int key);
        Task<List<DataTable>> ExecuteStoredProcedure(string storeProcedure, params (string, object)[] parameter);
    }
}
