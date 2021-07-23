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
using System.IO;
using System.Data;
using System.Collections.Generic;
using Services.Common.Utilities;
using Services.Common.Media;

namespace OperationManager.CRUD.Api.Controllers.v1
{
    public class WarehouseGoodsLogController : APIControllerBase
    {
        const string VALIDATION_ERROR = "The request failed due to a validation error";
        public string nameEF = OperationManagerConstants.WarehouseGoodsLog_TABLENAME;
        const string ReportWarehouseGoodsLog = nameof(ReportWarehouseGoodsLog);
        protected readonly IQuanLyVanHanhRepository<WarehouseGoodsLog> _quanLyVanHanhRepository;
        public WarehouseGoodsLogController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IQuanLyVanHanhRepository<WarehouseGoodsLog> quanLyVanHanhRepository) : base(mapper, httpContextAccessor)
        {
            _quanLyVanHanhRepository = quanLyVanHanhRepository;
        }
        /// <summary>
        /// Get List of WarehouseGoodsLog.
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
        /// Create  of WarehouseGoodsLog.
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
                var model = new WarehouseGoodsLog();
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
        /// Update of WarehouseGoodsLog.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromForm] int key, [FromForm] string values)
        {
            try
            {
                WarehouseGoodsLog model = new WarehouseGoodsLog();
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
        /// Delete of WarehouseGoodsLog.
        /// </summary>
        /// <param name="WarehouseGoodsLog"></param>
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
        /// <summary>
        /// DownLoad FilesAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route(ReportWarehouseGoodsLog)]
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<dynamic>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DownReportAsync(int id)
        {
            var methodResult = new MethodResult<dynamic>();
            ErrorResult err = new ErrorResult();
            err.ErrorCode = "101";
            err.ErrorMessage = "File không tồn tại";
            var memoryStream = new MemoryStream();
            //D:\duan\Content
            //F:\TayHo\SystemCore\AppService\Web\QuanLyDuAn\Content
            string _template = @"D:\duan\Content\Template\OperationManagement\Report0003_WarehouseGoodsLog.xlsx";
            try
            {

                if (id > 0)
                {
                    var files = Path.GetFileNameWithoutExtension(_template);
                    string ext = Path.GetExtension(_template).ToLowerInvariant();
                    List<DataTable> dataTables = new List<DataTable>();
                    ext = string.IsNullOrEmpty(ext) ? "xlsx" : ext;
                    (string, object)[] parameter = new (string, object)[] { ("@RecordId", id) };

                    dataTables = await _quanLyVanHanhRepository.ExecuteStoredProcedure("sp_Report0003_WarehouseGoodsLog", parameter);
                    memoryStream = EpplusHelper.Export(dataTables[0], "R001", false, _template, 1, 3, false);
                    memoryStream.Position = 0;
                    return File(memoryStream, FileHelpers.GetMimeTypes()[ext], Path.GetFileNameWithoutExtension(_template) + DateTime.Now.ToString("yyyyMMdd") + ext);
                }
                else
                {
                    methodResult.AddErrorMessage(err);
                    return BadRequest(methodResult);
                }
            }
            catch (Exception ex)
            {
                methodResult.AddErrorMessage(err);
                return BadRequest(methodResult);
            }

        }

    }
}
