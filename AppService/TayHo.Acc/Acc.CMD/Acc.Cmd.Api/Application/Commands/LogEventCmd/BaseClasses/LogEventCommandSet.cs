using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class LogEventCommandSet : BaseCommandClasses
    {
        public int? UserId { get; set; }
        public string Event { get; set; }
        public string Action { get; set; }
        public int? OwnerById { get; set; }
        public string OwnerByTable { get; set; }
        public int? FunctionId { get; set; }
        public string Message { get; set; }
    }
}