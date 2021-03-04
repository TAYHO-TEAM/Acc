using Microsoft.AspNetCore.Http;
using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DocumentReleasedCommandSet : BaseCommandClasses
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? ProjectId { get; set; }
        public int? WorkItemId { get; set; }
        public string TagWorkItem { get; set; }
        public string Location { get; set; }
        public DateTime? Calendar { get; set; }
        public byte? NoAttachment { get; set; }
        private IFormFileCollection _formFiles { get; set; }
        public void setFile(IFormFileCollection FormFiles)
        {
            _formFiles = FormFiles;
        }
        public IFormFileCollection getFile()
        {
            return _formFiles;
        }
    }
}