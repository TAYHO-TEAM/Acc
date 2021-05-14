using Microsoft.AspNetCore.Http;
using Services.Common.Media;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acc.Cmd.Domain.Services
{
    public interface IMediaService
    {
        Task<List<MediaResponse>> UploadFileAsync(IEnumerable<IFormFile> formFiles);
        Task<int> SaveFile(IFormFileCollection files);
        Task<FileResponse> FetechFiles(string subDirectory);
    }
}
