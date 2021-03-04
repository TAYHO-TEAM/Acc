using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NotifyAccountCommandSet : BaseCommandClasses
    {
        public int? AccountId { get; set; }
        public int? GroupId { get; set; }
        public int? NotifyId { get; set; }
        public DateTime? PushTime { get; set; }
    }
}
