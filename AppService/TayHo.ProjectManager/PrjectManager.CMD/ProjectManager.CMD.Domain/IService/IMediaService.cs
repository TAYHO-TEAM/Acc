using Microsoft.AspNetCore.Http;
using Services.Common.Media;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Domain.IService
{
    public interface IMediaService
    {
        //Task<List<MediaResponse>> UploadFileAsync(IEnumerable<IFormFile> formFiles);
        Task<Tuple<string, string, string,string,string>> SaveFile(IFormFile files, string Folder, string filename);
        Task<FileResponse> FetechFilesZip(string subDirectory);
        Task<MemoryStream> FetechFiles(string subDirectory);
    }
}
