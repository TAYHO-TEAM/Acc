using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationManager.CRUD.Api.Controllers.v1.BaseClasses;
using Services.Common.DevExpress;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using Services.Common.DomainObjects.Exceptions;
using OperationManager.CRUD.DAL.DTO;
using OperationManager.CRUD.BLL.IRepositories.BaseClasses;
using OperationManager.CRUD.Common;


namespace OperationManager.CRUD.Api.Controllers.v1
{
    public class ConstructionItemsController : APIControllerBase
    {
        const string VALIDATION_ERROR = "The request failed due to a validation error";
        public string nameEF = OperationManagerConstants.ConstructionItems_TABLENAME;
        const string Get = nameof(Get); 
        protected readonly IQuanLyVanHanhRepository<ConstructionItems> _quanLyVanHanhRepository;
        public ConstructionItemsController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IQuanLyVanHanhRepository<ConstructionItems> quanLyVanHanhRepository) : base(mapper, httpContextAccessor)
        {
            _quanLyVanHanhRepository = quanLyVanHanhRepository;
        }
        /// <summary>
        /// Get List of Items.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Get)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromForm]DataSourceLoadOptionsHelper loadOptions)
        {
            return Ok(await _quanLyVanHanhRepository.GetAll(_user, nameEF, loadOptions));
        }
        /// <summary>
        /// Create  of Items.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> Insert([FromBody] FormDataCollection form)
        public async Task<IActionResult> Post([FromForm]string values)
      {
            var methodResult = new MethodResult<object>();
            try
            {
                if (!ModelState.IsValid) throw new CommandHandlerException(new ErrorResult());
                var model = new ConstructionItems();
                JsonConvert.PopulateObject(values, model);
                return Ok(await _quanLyVanHanhRepository.Insert(_user, nameEF, model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(HttpStatusCode.BadRequest);
            }
        }
        /// <summary>
        /// Update of Items.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromForm] int key, [FromForm] string values)
        {
            try
            {
                ConstructionItems model = new ConstructionItems();
                JsonConvert.PopulateObject(values, model);
                model.Id = key;
                return Ok(await _quanLyVanHanhRepository.Update(_user, nameEF, model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete of Items.
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete([FromForm] int key)
        {
            try
            {
                return Ok(await _quanLyVanHanhRepository.Delete(_user, nameEF, key));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(HttpStatusCode.BadRequest);
            }

        }

    }
}
