using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class RequestDetailCommandSet : BaseCommandClasses
    {
        public int? RequestId { get; set; }
        public int? ProblemCategoryId { get; set; }
        public int? ReplyByID { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string Note { get; set; }
        public int? DurationDate { get; set; }
        public string StatusText { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public byte? NoAttachment { get; set; }
    }
}