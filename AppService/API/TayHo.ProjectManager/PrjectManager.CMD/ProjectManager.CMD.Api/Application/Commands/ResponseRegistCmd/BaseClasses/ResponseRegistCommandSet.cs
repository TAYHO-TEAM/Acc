using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ResponseRegistCommandSet : BaseCommandClasses
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? StepProcessId { get; set; }
        public int? RequestRegistId { get; set; }
        public int? GroupId { get; set; }
        public int? ReplyId { get; set; }
        public byte? NoAttachment { get; set; }
        public bool? IsApprove { get; set; }
        public byte? TypeOfResult { get; set; }
        private IFormFileCollection? FormFiles { get; set; }
    }
}