using Services.Common;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Acc.Cmd.Domain.Services;
using Services.Common.Media;
using Services.Common.Utilities;
using System.IO;
using System.IO.Compression;
using Services.Common.Options;
using Microsoft.AspNetCore.Hosting;

namespace Acc.Cmd.Infrastructure.Services
{
    public class MediaService : IMediaService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpClientFactory _clientFactory;
        private readonly MediaOptions _mediaOptions;
        public MediaService(IOptionsSnapshot<MediaOptions> snapshotOptionsAccessor, IHttpClientFactory clientFactory, IWebHostEnvironment env)
        {
            _mediaOptions = snapshotOptionsAccessor.Value;
            _clientFactory = clientFactory;
            _env = env;
        }

        public async Task<List<MediaResponse>> UploadFileAsync(IEnumerable<IFormFile> formFiles)
        {
            if (formFiles == null || !formFiles.Any()) return default;
            var listOfMediaResponse = new List<MediaResponse>();
            var fileType = new FileType();
            var client = _clientFactory.CreateClient();
            int i = 0;

            foreach (var formFile in formFiles)
            {
                var fileTypeVerifyResult = await fileType.ProcessFormFile(formFile, _mediaOptions.PermittedExtensions, _mediaOptions.SizeLimit);
                HandleFileErrorCode(fileTypeVerifyResult);
                MultipartFormDataContent content = new MultipartFormDataContent();
                StringContent strFolderName = new StringContent(_mediaOptions.FolderForWeb);
                ByteArrayContent byteArrayContent = new ByteArrayContent(fileTypeVerifyResult.Result);

                content.Add(strFolderName, "pFolder");
                content.Add(byteArrayContent, "File" + i, Uri.EscapeDataString(formFile.FileName));

                var response = await client.PostAsync(new Uri(string.Concat(_mediaOptions.MediaUploadUrl.ToString())), content);
                var resultApi = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(resultApi))
                {
                    var lstOfMediaIntegrationResponse = JsonConvert.DeserializeObject<List<MediaIntegrationResponse>>(resultApi);
                    if (lstOfMediaIntegrationResponse != null && lstOfMediaIntegrationResponse.Any())
                        listOfMediaResponse.AddRange(lstOfMediaIntegrationResponse.Select(x => new MediaResponse(x.TenFile, x.DuongDan, x.DungLuong)));
                }
                i++;
            }
            return listOfMediaResponse;
        }

        private void HandleFileErrorCode(FileTypeVerifyResult fileTypeVerifyResult)
        {
            ErrorResult errorResult;
            switch (fileTypeVerifyResult.Error)
            {
                case EFileError.InValidSignature:
                    errorResult = new ErrorResult
                    {
                        ErrorCode = CommonErrors.APIInValidFileSignature,
                        ErrorMessage = ErrorHelpers.GetCommonErrorMessage(CommonErrors.APIInValidFileSignature)
                    };
                    throw new ServiceException(errorResult);
                case EFileError.InValidExtension:
                    errorResult = new ErrorResult
                    {
                        ErrorCode = CommonErrors.APIInValidFileExtension,
                        ErrorMessage = ErrorHelpers.GetCommonErrorMessage(CommonErrors.APIInValidFileExtension)
                    };
                    throw new ServiceException(errorResult);
                case EFileError.InValidSize:
                    errorResult = new ErrorResult
                    {
                        ErrorCode = CommonErrors.APIInValidFileSize,
                        ErrorMessage = ErrorHelpers.GetCommonErrorMessage(CommonErrors.APIInValidFileSize)
                    };
                    throw new ServiceException(errorResult);
                case EFileError.InValid:
                    errorResult = new ErrorResult
                    {
                        ErrorCode = CommonErrors.APIInValidFile,
                        ErrorMessage = ErrorHelpers.GetCommonErrorMessage(CommonErrors.APIInValidFile)
                    };
                    throw new ServiceException(errorResult);
                default:
                    break;
            }
        }




        public async Task<int> SaveFile(IFormFileCollection files)
        {
            //subDirectory = subDirectory ?? string.Empty;
            int result = 0;
            //foreach (var file in files)
            //{
            //    if (file.Length <= 0) return 0;
            //    //    var filePath = Path.Combine(target, file.FileName);
            //    //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    //    {
            //    //        await file.CopyToAsync(stream);
            //    //    }
            //}
            try
            {
                var uploadPath = Path.Combine(_env.ContentRootPath, "/Uploads"); 
                Directory.CreateDirectory(uploadPath);
                var provider = new MultipartFormDataStreamProvider(uploadPath);
                var target = Path.Combine(@"f:\upload\");

                Directory.CreateDirectory(target);
                foreach (var file in files)
                {
                    if (file.Length <= 0) return 0;
                    var filePath = Path.Combine(target, file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            catch
            {
                result=  0;
            }
            return  result;
        }

        public async Task<FileResponse> FetechFiles(string subDirectory)
        {
            var zipName = $"archive-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

            var files = Directory.GetFiles(Path.Combine(@"D:\upload\", subDirectory)).ToList();

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    files.ForEach(file =>
                    {
                        var theFile = archive.CreateEntry(file);
                        using (var streamWriter = new StreamWriter(theFile.Open()))
                        {
                            streamWriter.Write(File.ReadAllText(file));
                        }

                    });
                }

                return new FileResponse("application/zip", memoryStream.ToArray(), zipName);
            }

        }

        public static string SizeConverter(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }

    }
}
