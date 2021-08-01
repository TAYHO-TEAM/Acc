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
using System.IO;
using Services.Common.Media;
using System.Data;
using System.Collections.Generic;
using Services.Common.Utilities;

namespace OperationManager.CRUD.Api.Controllers.v1
{
    public class ComplaintController : APIControllerBase
    {
        const string VALIDATION_ERROR = "The request failed due to a validation error";
        const string ReportComplaint = nameof(ReportComplaint);
        public string nameEF = OperationManagerConstants.Complaint_TABLENAME;
        protected readonly IQuanLyVanHanhRepository<Complaint> _quanLyVanHanhRepository;
        public ComplaintController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IQuanLyVanHanhRepository<Complaint> quanLyVanHanhRepository) : base(mapper, httpContextAccessor)
        {
            _quanLyVanHanhRepository = quanLyVanHanhRepository;
        }
        /// <summary>
        /// Get List of Complaint.
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
        /// Create  of Complaint.
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
                var model = new Complaint();
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
        /// Update of Complaint.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromForm] int key, [FromForm] string values)
        {
            try
            {
                Complaint model = new Complaint();
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
        /// Delete of Complaint.
        /// </summary>
        /// <param name="Complaint"></param>
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
        [Route(ReportComplaint)]
        [HttpGet]
        //[ProducesResponseType(typeof(MethodResult<dynamic>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DownReportAsync(int id)
        {
            var methodResult = new MethodResult<dynamic>();
            ErrorResult err = new ErrorResult();
            err.ErrorCode = "101";
            err.ErrorMessage = "File không tồn tại";
            MemoryStream memoryStream = new MemoryStream();
            string _template = @"D:\duan\Content\Template\OperationManagement\Report0001_Complaint.xlsx";
            try
            {

                if (id > 0)
                {
                    var files = Path.GetFileNameWithoutExtension(_template);
                    string ext = Path.GetExtension(_template).ToLowerInvariant();
                    ext = string.IsNullOrEmpty(ext) ? ".xlsx" : ext;
                    List<DataTable> dataTables = new List<DataTable>();
                    (string, object)[] parameter = new (string, object)[] { ("@RecordId", id) };
                     
                    dataTables = await _quanLyVanHanhRepository.ExecuteStoredProcedure("sp_Report0001_Complaint", parameter);
                    memoryStream = EpplusHelper.Export(dataTables[0], "R001",false, _template, 1,3, false);
                   
                    //memoryStream.Position = 0;
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    return File(memoryStream, FileHelpers.GetMimeTypes()[ext], files + DateTime.Now.ToString("yyyyMMdd")+ ext);
                }
                else
                {
                    methodResult.AddErrorMessage(err);
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                methodResult.AddErrorMessage(err);
                return NotFound();
            }

        }
    }
}
