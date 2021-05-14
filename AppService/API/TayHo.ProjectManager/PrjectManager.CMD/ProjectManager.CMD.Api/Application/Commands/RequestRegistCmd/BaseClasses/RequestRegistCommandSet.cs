using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class RequestRegistCommandSet : BaseCommandClasses
    {
        public int? PlanRegisterId { get; set; }
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string Note { get; set; }
        public int? ParentId { get; set; }
        public int? Level { get; set; }
        public byte? NoAttachment { get; set; }
        public int? ProjectId { get; set; }
        public int? WorkItemId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? Rev { get; set; }
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