using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using OperationManagement.Api.Controllers.v1.BaseClasses;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.DomainObjects;
using System.Net;


namespace OperationManagement.Api.Controllers.v1
{
    public class ValuesController : APIControllerBase
    {
        private const string Districts = nameof(Districts);
        public ValuesController(IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
        }

        /// <summary>
        /// Create a new Test.
        /// </summary>
        /// <param name="Districts"></param>
        /// <returns></returns>
        //[Route(Districts)]
        [HttpGet]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll(DataSourceLoadOptions loadOptions)
        {
            //var list = from x in _dbContext.DocumentReleased
            //           where x.IsDelete == false
            //           orderby x.Id
            //           select new { x.Code, x.Description, x.Id, x, x.IsDelete, x.IsModify, x.Location };
            //return await DataSourceLoader.LoadAsync(list, loadOptions);
            //var methodResult = new MethodResult<PagingItems<DocumentReleased>>();
            var abc = new LoadResult();
            return Ok(abc);
        }
    }
}
