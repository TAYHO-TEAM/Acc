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
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;
using OperationManager.CRUD.BLL.IRepositories.BaseClasses;
using OperationManager.CRUD.Common;

namespace OperationManager.CRUD.Api.Controllers.v1
{
    public class ListOfLocationController : APIControllerBase
    {
        const string VALIDATION_ERROR = "The request failed due to a validation error";
        public string nameEF = OperationManagerConstants.ListOfLocation_TABLENAME;
        protected readonly IQuanLyVanHanhRepository<ListOfLocation> _quanLyVanHanhRepository;
        public ListOfLocationController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IQuanLyVanHanhRepository<ListOfLocation> quanLyVanHanhRepository) : base(mapper, httpContextAccessor)
        {
            _quanLyVanHanhRepository = quanLyVanHanhRepository;
        }
        /// <summary>
        /// Get List of ListOfLocation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] DataLoadOptionsHelper loadOptions)
        {
            return Ok(await _quanLyVanHanhRepository.GetAll(_user, nameEF, loadOptions));
        }
        /// <summary>
        /// Create  of ListOfLocation.
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
                var model = new ListOfLocation();
                if (!string.IsNullOrEmpty(values))
                    JsonConvert.PopulateObject(values, model);
                IFormFileCollection files = Request.Form.Files;
                return Ok(await _quanLyVanHanhRepository.Insert(_user, nameEF, model, files));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(HttpStatusCode.BadRequest);
            }
        }
        /// <summary>
        /// Update of ListOfLocation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromForm] int key, [FromForm] string values)
        {
            try
            {
                ListOfLocation model = new ListOfLocation();
                if (!string.IsNullOrEmpty(values))
                    JsonConvert.PopulateObject(values, model);
                IFormFileCollection files = Request.Form.Files;
                model.Id = key;
                return Ok(await _quanLyVanHanhRepository.Update(_user, nameEF, model, files));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete of ListOfLocation.
        /// </summary>
        /// <param name="ListOfLocation"></param>
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
