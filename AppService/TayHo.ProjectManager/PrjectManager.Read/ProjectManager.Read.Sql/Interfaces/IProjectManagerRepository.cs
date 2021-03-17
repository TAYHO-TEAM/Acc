using DevExtreme.AspNet.Data.ResponseModel;
using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface IProjectManagerRepository
    {
        Task<LoadResult> GetAll(int user,string nameEF,DevLoadOptionsBase dataSourceLoadOptions, string searchOperation, string searchValue, List<string> searchExpr);
        Task<string> GetAccount2( DevLoadOptionsBase dataSourceLoadOptions);
    }

}
