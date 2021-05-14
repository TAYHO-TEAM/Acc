using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class SysJobCommandSet : BaseCommandClasses
    {
        public int TemplateId { get; set; }
        public string JobName { get; set; }
        public string NameDataBase { get; set; }
        public string NameStoreProce { get; set; }
        public string ConnStringHash { get; set; }
        public string Salt { get; set; }
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
        public bool? IsTemplate { get; set; }

    }
}
