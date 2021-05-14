using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class SysAutoSendMailCommandSet : BaseCommandClasses
    {
        public int? SysJobId { get; set; }
        public int? TemplateMailId { get; set; }
        public string SubMail { get; set; }
        public string TitleMail { get; set; }
        public string BodyMail { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? FirstDate { get; set; }
        public DateTime? LastDate { get; set; }
        public DateTime? NextDate { get; set; }
        public int? Times { get; set; }
        public byte? Unit { get; set; }
        public int? StepTime { get; set; }

    }
}
