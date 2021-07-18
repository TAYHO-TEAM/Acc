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
using Services.Common.Media;

namespace OperationManager.CRUD.Api.Controllers.v1
{
    public class FilesAttachmentController : APIControllerBase
    {
        const string VALIDATION_ERROR = "The request failed due to a validation error";
        const string Get = nameof(Get);
        private const string DownLoadFile = nameof(DownLoadFile);
        public string nameEF = OperationManagerConstants.FilesAttachment_TABLENAME;
        protected readonly IQuanLyVanHanhRepository<FilesAttachment> _quanLyVanHanhRepository;
        public FilesAttachmentController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IQuanLyVanHanhRepository<FilesAttachment> quanLyVanHanhRepository) : base(mapper, httpContextAccessor)
        {
            _quanLyVanHanhRepository = quanLyVanHanhRepository;
        }
        /// <summary>
        /// Get List of FilesAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[HttpPost]
        [HttpGet]
        //[Route(Get)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] DataLoadOptionsHelper loadOptions)
        {
            return Ok(await _quanLyVanHanhRepository.GetAll(_user, nameEF, loadOptions));
        }
        /// <summary>
        /// Create  of FilesAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> Insert([FromBody] FormDataCollection form)
        public async Task<IActionResult> Post([FromForm] string values)
        {
            var methodResult = new MethodResult<object>();
            try
            {
                if (!ModelState.IsValid) throw new CommandHandlerException(new ErrorResult());
                var model = new FilesAttachment();
                JsonConvert.PopulateObject(values, model);
                return Ok(await _quanLyVanHanhRepository.Insert(_user, nameEF, model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(HttpStatusCode.BadRequest);
            }
        }
        /// <summary>
        /// Update of FilesAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromForm] int key, [FromForm] string values)
        {
            try
            {
                FilesAttachment model = new FilesAttachment();
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
        /// Delete of FilesAttachment.
        /// </summary>
        /// <param name="FilesAttachment"></param>
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
        [Route(DownLoadFile)]
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<dynamic>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DownFilesAttachmentAsync(int id)
        {
            var methodResult = new MethodResult<dynamic>();
            ErrorResult err = new ErrorResult();
            err.ErrorCode = "101";
            err.ErrorMessage = "File không tồn tại";
            var memoryStream = new MemoryStream();

            //try
            //{
            //    RequestBaseFilterParam requestFilter = new RequestBaseFilterParam();
            //    requestFilter.FindId = id.ToString();
            //    requestFilter.TableName = QuanLyDuAnConstants.FilesAttachment_TABLENAME;
            //    var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);

            //    if (queryResult.Items.ToList().Count > 0)
            //    {
            //        FilesAttachmentDTO oldFile = queryResult.Items.ToList()[0];
            //        var files = Path.GetFileName(oldFile.Direct.ToString()).ToList();
            //        string filename = oldFile.DisplayName.ToString();


            //        if (string.IsNullOrEmpty(filename))
            //            filename = string.IsNullOrEmpty(oldFile.FileName.ToString()) ? "" : oldFile.FileName.ToString();


            //        using (var stream = new FileStream(oldFile.Direct.ToString(), FileMode.Open))
            //        {
            //            await stream.CopyToAsync(memoryStream);
            //        }
            //        memoryStream.Position = 0;
            //        string ext = Path.GetExtension(oldFile.Direct.ToString()).ToLowerInvariant();
            //        return File(memoryStream, FileHelpers.GetMimeTypes()[ext], filename);

            //    }
            //    else
            //    {
            //        methodResult.AddErrorMessage(err);
            //        //if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            //        return File(memoryStream, "");
            //    }
            //}
            //catch
            //{
            //    methodResult.AddErrorMessage(err);
            //    //if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
                return File(memoryStream, "");
            //return BadRequest(ErrorResult);
            //}
        }
    }
}
