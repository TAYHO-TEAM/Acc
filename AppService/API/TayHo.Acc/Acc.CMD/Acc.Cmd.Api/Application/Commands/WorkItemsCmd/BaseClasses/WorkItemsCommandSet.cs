using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class WorkItemsCommandSet : BaseCommandClasses
    {
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? level { get; set; }
        public int? ProjectId { get; set; }
    }
}