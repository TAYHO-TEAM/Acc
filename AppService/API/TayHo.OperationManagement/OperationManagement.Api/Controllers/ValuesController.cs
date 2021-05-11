using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using OperationManagement.Api.Controllers.v1.BaseClasses;
using System.Threading.Tasks;
using System.Linq;

namespace OperationManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : APIControllerBase
    {
        private const string Districts = nameof(Districts);
        [Route(Districts)]
        public async Task<LoadResult> GetAll(DataSourceLoadOptions loadOptions)
        {
            var list = from x in _dbContext.DocumentReleased
                       where x.IsDelete == false
                       orderby x.Id
                       select new { x.Code, x.Description, x.Id, x, x.IsDelete, x.IsModify, x.Location };
            return await DataSourceLoader.LoadAsync(list, loadOptions);
        }
    }
}
