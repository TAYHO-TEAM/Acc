using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class FilesAttachmentCommandSet : BaseCommandClasses
    {
        public int? OwnerById { get; set; }
        public string OwnerByTable { get; set; }
        public string Code { get; set; }
        public string FileName { get; set; }
        public string Tail { get; set; }
        public string Url { get; set; }
        public string Host { get; set; }
        public string Type { get; set; }
        public string Direct { get; set; }
        private IFormFile _formFiles { get; set; }
        public void setFile(IFormFile FormFiles )
        {
            _formFiles = FormFiles;
        }
        public IFormFile getFile()
        {
           return _formFiles;
        }
    }
}