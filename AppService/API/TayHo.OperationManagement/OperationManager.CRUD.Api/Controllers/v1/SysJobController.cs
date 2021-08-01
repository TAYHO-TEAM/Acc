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
    public class SysJobController : APIControllerBase
    {
        const string VALIDATION_ERROR = "The request failed due to a validation error";
        public string nameEF = ProjectManagerConstants.SysJob_TABLENAME;
        protected readonly IQuanLyDuAnRepository<SysJob> _quanLyDuAnRepository;
        public SysJobController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IQuanLyDuAnRepository<SysJob> quanLyDuAnRepository) : base(mapper, httpContextAccessor)
        {
            _quanLyDuAnRepository = quanLyDuAnRepository;
        }
        /// <summary>
        /// Get List of SysJob.
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
        /// Create  of SysJob.
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
                var model = new SysJob();
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
        /// Update of SysJob.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromForm] int key, [FromForm] string values)
        {
            try
            {
                SysJob model = new SysJob();
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
        /// Delete of SysJob.
        /// </summary>
        /// <param name="SysJob"></param>
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
