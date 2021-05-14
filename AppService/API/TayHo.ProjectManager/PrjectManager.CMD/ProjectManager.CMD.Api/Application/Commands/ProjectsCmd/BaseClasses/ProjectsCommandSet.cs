using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ProjectsCommandSet : BaseCommandClasses
    {
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public int? ParentId { get; set; }
        public int? NodeLevel { get; set; }
        public int? OldId { get; set; }
    }
}