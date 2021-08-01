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
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;
using OperationManager.CRUD.BLL.IRepositories.BaseClasses;
using OperationManager.CRUD.Common;

namespace OperationManager.CRUD.Api.Controllers.v1
{
    public class SysSettingController : APIControllerBase
    {
        const string VALIDATION_ERROR = "The request failed due to a validation error";
        public string nameEF = ProjectManagerConstants.SysSetting_TABLENAME;
        protected readonly IQuanLyDuAnRepository<SysSetting> _quanLyDuAnRepository;
        public SysSettingController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IQuanLyDuAnRepository<SysSetting> quanLyDuAnRepository) : base(mapper, httpContextAccessor)
        {
            _quanLyDuAnRepository = quanLyDuAnRepository;
        }
        /// <summary>
        /// Get List of SysSetting.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] DataLoadOptionsHelper loadOptions)
        {
            return Ok(await _quanLyDuAnRepository.GetAll(_user, nameEF, loadOptions));
        }
        /// <summary>
        /// Create  of SysSetting.
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
                var model = new SysSetting();
                if (!string.IsNullOrEmpty(values))
                    JsonConvert.PopulateObject(values, model);
                IFormFileCollection files = Request.Form.Files;
                return Ok(await _quanLyDuAnRepository.Insert(_user, nameEF, model, files));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(HttpStatusCode.BadRequest);
            }
        }
        /// <summary>
        /// Update of SysSetting.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromForm] int key, [FromForm] string values)
        {
            try
            {
                SysSetting model = new SysSetting();
                if (!string.IsNullOrEmpty(values))
                    JsonConvert.PopulateObject(values, model);
                IFormFileCollection files = Request.Form.Files;
                model.Id = key;
                return Ok(await _quanLyDuAnRepository.Update(_user, nameEF, model, files));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete of SysSetting.
        /// </summary>
        /// <param name="SysSetting"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete([FromForm] int key)
        {
            try
            {
                return Ok(await _quanLyDuAnRepository.Delete(_user, nameEF, key));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(HttpStatusCode.BadRequest);
            }

        }

    }
}
