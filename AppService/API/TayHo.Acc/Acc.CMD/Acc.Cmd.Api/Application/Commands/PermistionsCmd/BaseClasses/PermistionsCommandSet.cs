using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class PermistionsCommandSet : BaseCommandClasses
    {
        public byte Type { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
    }
}