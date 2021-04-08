using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Common;
using ProjectManager.Read.Api.Controllers.v1.BaseClasses;
using ProjectManager.Read.Api.ViewModels.BaseClasses;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.DomainObjects;
using Services.Common.Paging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Services.Common.Media;
using System.Linq;
using Services.Common.DomainObjects.Exceptions;

namespace ProjectManager.Read.Api.Controllers.v1
{
    public class FilesAttachmentController : APIControllerBase
    {
        private readonly IDOBaseRepository<FilesAttachmentDTO> _dOBaseRepository;
        private readonly IFilesAttachmentRepository<FilesAttachmentDTO> _filesAttachmentRepository;
        private const string getBy = nameof(getBy);
        private const string down = nameof(down);
        private const int err = 0;
        public FilesAttachmentController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<FilesAttachmentDTO> dOBaseRepository, IFilesAttachmentRepository<FilesAttachmentDTO> filesAttachmentRepository) : base(mapper, httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _filesAttachmentRepository = filesAttachmentRepository;
        }

        /// <summary>
        /// Get List of FilesAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<FilesAttachmentResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetFilesAttachmentAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<FilesAttachmentResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.FilesAttachment_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<FilesAttachmentResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<FilesAttachmentResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of FilesAttachment Get By.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(getBy)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<FilesAttachmentResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetFilesAttachmentByAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<FilesAttachmentResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.FilesAttachment_TABLENAME;
            var queryResult = await _filesAttachmentRepository.GetFilesAttachmentByAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<FilesAttachmentResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<FilesAttachmentResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// DownLoad FilesAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route(down)]
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

            try
            {
                RequestBaseFilterParam requestFilter = new RequestBaseFilterParam();
                requestFilter.FindId = id.ToString();
                requestFilter.TableName = QuanLyDuAnConstants.FilesAttachment_TABLENAME;
                var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
                
                if (queryResult.Items.ToList().Count > 0)
                {
                    FilesAttachmentDTO oldFile = queryResult.Items.ToList()[0];
                    var files = Path.GetFileName(oldFile.Direct.ToString()).ToList();
                    string filename = oldFile.DisplayName.ToString();


                    if (string.IsNullOrEmpty(filename))
                        filename = string.IsNullOrEmpty(oldFile.FileName.ToString()) ? "" : oldFile.FileName.ToString();


                    using (var stream = new FileStream(oldFile.Direct.ToString(), FileMode.Open))
                    {
                        await stream.CopyToAsync(memoryStream);
                    }
                    memoryStream.Position = 0;
                    var ext = Path.GetExtension(oldFile.Direct.ToString()).ToLowerInvariant();
                    return File(memoryStream, FileHelpers.GetMimeTypes()[ext], filename);

                }
                else
                {
                    methodResult.AddErrorMessage(err);
                    //if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
                    return File(memoryStream, "");
                }
            }
            catch
            {
                methodResult.AddErrorMessage(err);

                //if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
                return File(memoryStream, "");
            }
        }
    }
}
