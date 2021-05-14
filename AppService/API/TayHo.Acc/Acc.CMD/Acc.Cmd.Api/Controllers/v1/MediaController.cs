using Acc.Cmd.Api.Controllers.v1.BaseClasses;
using Services.Common.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Acc.Cmd.Domain.Services;
using Services.Common.Media;
using System.IO;
using Services.Common.Utilities;
using Microsoft.Net.Http.Headers;
using Services.Common.Options;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Http.Features;

namespace Acc.Cmd.Api.Controllers.V1
{
    public class MediaController : APIControllerBase
    {

        private const string UploadFile = nameof(UploadFile);
        private const string SaveFile = nameof(SaveFile);
        private const string SavePhysical = nameof(SavePhysical);
        private const string DownloadFile = nameof(DownloadFile);
        private readonly IMediaService _mediaService;

        private static readonly FormOptions _defaultFormOptions = new FormOptions();
        private readonly long _fileSizeLimit=2000000;
        private readonly string[] _permittedExtensions = { ".txt", ".png" , ".jpg" , "." };
        private readonly string _targetFilePath = @"F:\upload\";

        public MediaController(IMediator mediator, IMediaService mediaService) : base(mediator)
        {
            _mediaService = mediaService;
        }

        /// <summary>
        /// Upload files.
        /// </summary>
        /// <param name="formFiles"></param>
        /// <returns></returns>
        [HttpPost(UploadFile)]
        [ProducesResponseType(typeof(MethodResult<List<MediaResponse>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UploadFileAsync(IEnumerable<IFormFile> formFiles)
        {
            var methodResult = new MethodResult<List<MediaResponse>>();
            methodResult.Result = await _mediaService.UploadFileAsync(formFiles).ConfigureAwait(false);
            return Ok(methodResult);
        }
        /// <summary>
        /// DownLoadFiles
        /// </summary>
        /// <param name="subDirectory"></param>
        /// <returns></returns>
        [HttpGet(DownloadFile)]
        [ProducesResponseType(typeof(MethodResult<List<MediaResponse>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DownloadFiles(string subDirectory)
        {
            var methodResult = new MethodResult<FileResponse>();
            methodResult.Result = await _mediaService.FetechFiles(subDirectory).ConfigureAwait(false);
            return Ok(methodResult);

        }
        /// <summary>
        /// SaveFile
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost(SaveFile)]
        [ProducesResponseType(typeof(MethodResult<List<int>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SaveFileAsync([FromForm] IFormFileCollection files)
        {
            var methodResult = new MethodResult<int>();
            methodResult.Result = await _mediaService.SaveFile(files).ConfigureAwait(false);
            return Ok(methodResult);

        }
        [HttpPost(SavePhysical)]
        //[DisableFormValueModelBinding]
        //[ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(MethodResult<List<int>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UploadPhysical()
        {
            var methodResult = new MethodResult<int>();
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
            {
                //ModelState.AddModelError("File",
                //    $"The request couldn't be processed (Error 1).");
                // Log error

                //return BadRequest(ModelState);
               
                return Ok(methodResult.Result=0);
            }

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(Request.ContentType),
                _defaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);
            var section = await reader.ReadNextSectionAsync();

            while (section != null)
            {
                var hasContentDispositionHeader =
                    ContentDispositionHeaderValue.TryParse(
                        section.ContentDisposition, out var contentDisposition);

                if (hasContentDispositionHeader)
                {
                    // This check assumes that there's a file
                    // present without form data. If form data
                    // is present, this method immediately fails
                    // and returns the model error.
                    if (!MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
                    {
                        ModelState.AddModelError("File", $"The request couldn't be processed (Error 2).");
                        // Log error

                        //return BadRequest(ModelState);
                        return Ok(methodResult);
                    }
                    else
                    {
                        // Don't trust the file name sent by the client. To display
                        // the file name, HTML-encode the value.
                        var trustedFileNameForDisplay = WebUtility.HtmlEncode(contentDisposition.FileName.Value);
                        var trustedFileNameForFileStorage = Path.GetRandomFileName();

                        // **WARNING!**
                        // In the following example, the file is saved without
                        // scanning the file's contents. In most production
                        // scenarios, an anti-virus/anti-malware scanner API
                        // is used on the file before making the file available
                        // for download or for use by other systems. 
                        // For more information, see the topic that accompanies 
                        // this sample.

                        var streamedFileContent = await FileHelpers.ProcessStreamedFile(
                            section, contentDisposition, ModelState,
                            _permittedExtensions, _fileSizeLimit);

                        //if (!ModelState.IsValid)
                        //{
                        //    return BadRequest(ModelState);
                        //}

                        using (var targetStream = System.IO.File.Create(
                            Path.Combine(_targetFilePath, trustedFileNameForFileStorage)))
                        {
                            await targetStream.WriteAsync(streamedFileContent);

                            //    _logger.LogInformation(
                            //        "Uploaded file '{TrustedFileNameForDisplay}' saved to " +
                            //        "'{TargetFilePath}' as {TrustedFileNameForFileStorage}",
                            //        trustedFileNameForDisplay, _targetFilePath,
                            //        trustedFileNameForFileStorage);
                            //}
                        }
                    }

                    // Drain any remaining section body that hasn't been consumed and
                    // read the headers for the next section.
                    section = await reader.ReadNextSectionAsync();
                }
                //return Created(nameof(StreamingController), null);
                return Ok(methodResult);
            }
            return Ok(methodResult);
        }
    }
}

