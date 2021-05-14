using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class StepsProcessCommandSet : BaseCommandClasses
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public byte? Priority { get; set; }
        public int? ParentId { get; set; }
        public int? Level { get; set; }
        public int? PreviousId { get; set; }
        public int? NextId { get; set; }
        public int? OperationProcessId { get; set; }
    }
}