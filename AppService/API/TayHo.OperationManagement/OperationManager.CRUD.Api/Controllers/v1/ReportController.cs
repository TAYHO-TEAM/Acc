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
using System.Collections.Generic;
using Services.Common.Utilities;
using OperationManager.CRUD.BLL.IRepositories;
using Services.Common.Media;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace OperationManager.CRUD.Api.Controllers.v1
{
    public class ReportController : APIControllerBase
    {
        const string VALIDATION_ERROR = "The request failed due to a validation error";
        protected readonly IReportRepository _reportRepository;
        public ReportController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IReportRepository reportRepository) : base(mapper, httpContextAccessor)
        {
            _reportRepository = reportRepository;
        }
        /// <summary>
        /// DownLoad FilesAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<dynamic>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportAsync([FromForm] int key, [FromForm] string values)
        {
            var methodResult = new MethodResult<dynamic>();
            ErrorResult err = new ErrorResult();
            err.ErrorCode = "101";
            err.ErrorMessage = "File không tồn tại";
            string _template = @"D:\duan\Content\Template\OperationManagement\Report0002_DefectFeedback.xlsx";// @"F:\TayHo\SystemCore\AppService\Web\QuanLyDuAn\Content\Template\OperationManagement\Report0002_DefectFeedback.xlsx";// ;//F:\TayHo\SystemCore\AppService\Web\QuanLyDuAn\Content\Template\OperationManagement 
            try
            {

                var files = Path.GetFileNameWithoutExtension(_template);
                string ext = Path.GetExtension(_template).ToLowerInvariant();
                List<DataTable> dataTables = new List<DataTable>();
                ext = string.IsNullOrEmpty(ext) ? "xlsx" : ext;
                object obj = JsonConvert.DeserializeObject<dynamic>(values);
                (string, object)[] parameter = { };/// new (string, object)[] { ("@RecordId", id) };
                //foreach (JProperty item in obj.GetType())
                //{
                //    parameter[item.Children.]
                //}


                //dataTables = await _quanLyVanHanhRepository.ExecuteStoredProcedure("sp_Report0002_DefectFeedback", parameter);
                GenImage genImage = new GenImage();
                genImage.Height = 200;
                genImage.Width = 0;
                genImage.IsAutoCrop = true;
                genImage.IsGenIamge = true;
                genImage.ColImage = "Image,image,";
                var FileResult = await _reportRepository.ReportSheetGet(key, parameter);
                if (FileResult.Item1 == null || FileResult.Item2 == null || FileResult.Item3 == null)
                {
                    methodResult.AddErrorMessage(err);
                    return BadRequest(methodResult);
                }
                else
                {
                    return File(FileResult.Item1, FileResult.Item2, FileResult.Item3);
                }
            }
            catch (Exception ex)
            {
                methodResult.AddErrorMessage(err);
                return BadRequest(methodResult);
            }

        }
        /// <summary>
        /// DownLoad FilesAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<dynamic>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutReportAsync([FromForm] int key, [FromForm] string values)
        {
            var methodResult = new MethodResult<dynamic>();
            ErrorResult err = new ErrorResult();
            err.ErrorCode = "101";
            err.ErrorMessage = "File không tồn tại";
       
            try
            {
                
                (string, object)[] parameter = { };/// new (string, object)[] { ("@RecordId", id) };
                JObject obj = JObject.Parse(values);
                int i = 0;
                foreach (JProperty item in obj.Children())
                {
                    Array.Resize(ref parameter, parameter.Length + 1);
                    parameter[i] = (item.Name,ConvertHelper.ConvertJProperty(item));
                    i++;
                }
                var FileResult = await _reportRepository.ReportSheetGet(key, parameter);
                if (FileResult.Item1 == null || FileResult.Item2 == null || FileResult.Item3 == null)
                {
                    methodResult.AddErrorMessage(err);
                    return BadRequest(methodResult);
                }
                else
                {
                    Response.Headers.Add("X-File-Name", FileResult.Item3);
                    return File(FileResult.Item1, FileResult.Item2, FileResult.Item3);
                }
            }
            catch (Exception ex)
            {
                methodResult.AddErrorMessage(err);
                return BadRequest(methodResult);
            }
        }
        /// <summary>
        /// DownLoad FilesAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(MethodResult<dynamic>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostReportAsync([FromForm] int key, [FromForm] string values)
        {
            var methodResult = new MethodResult<dynamic>();
            ErrorResult err = new ErrorResult();
            err.ErrorCode = "101";
            err.ErrorMessage = "File không tồn tại";

            try
            {

                (string, object)[] parameter = { };/// new (string, object)[] { ("@RecordId", id) };
                JObject obj = JObject.Parse(values);
                int i = 0;
                foreach (JProperty item in obj.Children())
                {
                    Array.Resize(ref parameter, parameter.Length + 1);
                    parameter[i] = (item.Name, ConvertHelper.ConvertJProperty(item));
                    i++;
                }
                var FileResult = await _reportRepository.ReportSheetGet(key, parameter);
                if (FileResult.Item1 == null || FileResult.Item2 == null || FileResult.Item3 == null)
                {
                    methodResult.AddErrorMessage(err);
                    return BadRequest(methodResult);
                }
                else
                {
                    Response.Headers.Add("X-File-Name", FileResult.Item3);
                    return File(FileResult.Item1, FileResult.Item2, FileResult.Item3);
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
